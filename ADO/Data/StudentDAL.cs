using System;
using System.Data;
using System.Collections.Generic;
// using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using ADO.Models;

namespace ADO.Data
{
    public class StudentDAL
    {
        private readonly string connectionString;

        public StudentDAL(IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public void Init()
{
    using var con = new SqliteConnection(connectionString);
    con.Open();
    var cmd = con.CreateCommand();
    cmd.CommandText =
    @"CREATE TABLE IF NOT EXISTS Students(
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Name TEXT,
        Email TEXT,
        Address TEXT
      )";
    cmd.ExecuteNonQuery();
}

        // READ
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            using var con = new SqliteConnection(connectionString);
            using var cmd = new SqliteCommand("SELECT Id, Name, Email, Address FROM Students", con);

            con.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                students.Add(new Student
                {
                    Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                    Name = rdr["Name"] as string ?? string.Empty,
                    Email = rdr["Email"] as string ?? string.Empty,
                    Address = rdr["Address"] as string ?? string.Empty
                });
            }
            return students;
        }

        // CREATE
        public void AddStudent(Student student)
        {
            using var con = new SqliteConnection(connectionString);
            using var cmd = new SqliteCommand(
                "INSERT INTO Students(Name,Email,Address) VALUES(@Name,@Email,@Address)", con);

            cmd.Parameters.AddWithValue("@Name", student.Name ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", student.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", student.Address ?? (object)DBNull.Value);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // UPDATE
        public void UpdateStudent(Student student)
        {
            using var con = new SqliteConnection(connectionString);
            using var cmd = new SqliteCommand(
                "UPDATE Students SET Name=@Name, Email=@Email, Address=@Address WHERE Id=@Id", con);

            cmd.Parameters.AddWithValue("@Id", student.Id);
            cmd.Parameters.AddWithValue("@Name", student.Name ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", student.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", student.Address ?? (object)DBNull.Value);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void DeleteStudent(int id)
        {
            using var con = new SqliteConnection(connectionString);
            using var cmd = new SqliteCommand("DELETE FROM Students WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // GET BY ID
        public Student? GetStudentById(int id)
        {
            using var con = new SqliteConnection(connectionString);
            using var cmd = new SqliteCommand("SELECT Id, Name, Email, Address FROM Students WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) return null;

            return new Student
            {
                Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                Name = rdr["Name"] as string ?? string.Empty,
                Email = rdr["Email"] as string ?? string.Empty,
                Address = rdr["Address"] as string ?? string.Empty
            };
        }
    }
}
