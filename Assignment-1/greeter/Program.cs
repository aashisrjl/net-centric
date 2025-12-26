// using System;
// class Program
// {
//     static void Main()
//     {
//         string fullName = "Aashis Rijal";
//         Console.WriteLine(fullName);
//     }
// }
// //==================================
// using System;

// class Program
// {
//     static void Main()
//     {
//         string fullName = "Aashis Rijal";
//         string cFullName = fullName.ToUpper();
//         Console.WriteLine($"Hello, {cFullName} Ji!");
//     }
// }
// //===============================
// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter your full name: ");
//         string fullName = Console.ReadLine();

//         string cFullName = fullName.ToUpper();
//         Console.WriteLine($"Hello, {cFullName} Ji!");
//     }
// }

// //===================
// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter your full name: ");
//         string fullName = Console.ReadLine();

//         Console.Write("Enter your Date of Birth (YYYY/MM/DD): ");
//         string dobInput = Console.ReadLine();
//         DateTime dob = DateTime.Parse(dobInput);

//         Console.WriteLine($"Hello, {fullName} Ji!");
//         Console.WriteLine($"Your DOB: {dob:dddd, dd MMMM yyyy}");
//     }
// }
// //=======================
// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter your full name: ");
//         string fullName = Console.ReadLine();

//         Console.Write("Enter your Date of Birth (YYYY/MM/DD): ");
//         string dobInput = Console.ReadLine();
//         DateTime dob = DateTime.Parse(dobInput);
//         DateTime today = DateTime.Now;

//         // Calculate age parts
//         int years = today.Year - dob.Year;
//         int months = today.Month - dob.Month;
//         int days = today.Day - dob.Day;

//         if (days < 0)
//         {
//             months--;
//             days += DateTime.DaysInMonth(today.Year, (today.Month == 1 ? 12 : today.Month - 1));
//         }

//         if (months < 0)
//         {
//             years--;
//             months += 12;
//         }

//         Console.WriteLine($"Hello, {fullName} Ji!");
//         Console.WriteLine($"Your DOB: {dob:dddd, dd MMMM yyyy}");
//         Console.WriteLine($"Age as of now: {years} Years {months} Months {days} Days");
//     }
// }




