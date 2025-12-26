using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Assignment3
{
    // Model Class for CSV Data
    public class Inflation
    {
        public string RegionalMember { get; set; }
        public int Year { get; set; }
        public double InflationRate { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string Subregion { get; set; }
        public string CountryCode { get; set; }
    }

    // Analysis Class
    public class InflationAnalysis
    {
        // Method to read CSV and return List<Inflation>
        public List<Inflation> ReadInflationData(string filePath)
        {
            var data = new List<Inflation>();
            var lines = File.ReadAllLines(filePath).Skip(1); // skip header

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue; // skip empty lines

                var values = line.Split(',');

                // Trim spaces and quotes
                string regionalMember = values[0].Trim().Trim('"');
                string yearStr = values[1].Trim().Trim('"');
                string inflationStr = values[2].Trim().Trim('"');
                string unit = values[3].Trim().Trim('"');
                string subregion = values[4].Trim().Trim('"');
                string code = values[5].Trim().Trim('"');

                // Parse safely
                int year = 0;
                int.TryParse(yearStr, out year);

                double inflation = 0.0;
                double.TryParse(inflationStr, NumberStyles.Any, CultureInfo.InvariantCulture, out inflation);

                data.Add(new Inflation
                {
                    RegionalMember = regionalMember,
                    Year = year,
                    InflationRate = inflation,
                    UnitOfMeasurement = unit,
                    Subregion = subregion,
                    CountryCode = code
                });
            }

            return data;
        }

        // Query 1: Find inflation rates for countries for the year 2021
        public void InflationRates2021(List<Inflation> data)
        {
            var result = data.Where(i => i.Year == 2021);

            Console.WriteLine("\nInflation Rates in 2021:");
            foreach (var item in result)
                Console.WriteLine($"{item.RegionalMember}: {item.InflationRate}{item.UnitOfMeasurement}");
        }

        // Query 2: Year when Nepal has highest inflation
        public void NepalHighestInflation(List<Inflation> data)
        {
            var result = data
                .Where(i => i.RegionalMember == "Nepal")
                .OrderByDescending(i => i.InflationRate)
                .FirstOrDefault();

            if (result != null)
                Console.WriteLine($"\nNepal's highest inflation was in {result.Year}: {result.InflationRate}{result.UnitOfMeasurement}");
            else
                Console.WriteLine("\nNo data found for Nepal.");
        }

        // Query 3: Top 10 regions with highest inflation all time
        public void Top10HighestInflation(List<Inflation> data)
        {
            var result = data
                .OrderByDescending(i => i.InflationRate)
                .Take(10);

            Console.WriteLine("\nTop 10 Highest Inflation Records:");
            foreach (var item in result)
                Console.WriteLine($"{item.RegionalMember} ({item.Year}): {item.InflationRate}{item.UnitOfMeasurement}");
        }

        // Query 4: Top 3 South Asian countries with lowest inflation in 2020
        public void LowestInflationSouthAsia2020(List<Inflation> data)
        {
            var result = data
                .Where(i => i.Year == 2020 && i.Subregion == "South Asia")
                .OrderBy(i => i.InflationRate)
                .Take(3);

            Console.WriteLine("\nTop 3 South Asian Countries with Lowest Inflation in 2020:");
            foreach (var item in result)
                Console.WriteLine($"{item.RegionalMember}: {item.InflationRate}{item.UnitOfMeasurement}");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Inflation.csv"; // make sure this is correct path
            InflationAnalysis analysis = new InflationAnalysis();

            var inflationData = analysis.ReadInflationData(filePath);

            // analysis.InflationRates2021(inflationData);
            // analysis.NepalHighestInflation(inflationData);
            // analysis.Top10HighestInflation(inflationData);
            analysis.LowestInflationSouthAsia2020(inflationData);
        }
    }
}
