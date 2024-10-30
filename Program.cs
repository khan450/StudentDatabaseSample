using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabaseSample
{
    // Student class
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // SchoolContext class for Entity Framework
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }

    // Main Program class
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolContext())
            {
                // Prompt to enter a student's name
                Console.Write("Enter the name of a new Student: ");
                var name = Console.ReadLine();

                // Create and add a new Student
                var student = new Student { Name = name, Age = 20 };
                db.Students.Add(student);
                db.SaveChanges();

                // Retrieve and display all students
                var query = from s in db.Students
                            orderby s.Name
                            select s;

                Console.WriteLine("All students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine($"ID: {item.StudentId}, Name: {item.Name}, Age: {item.Age}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

