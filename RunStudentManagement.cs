//program will run from program.cs

using System;
using System.IO;

class Student
{
    public static void RunStudentManagement()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== Student Management System =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ViewStudents();
                    break;
                case "3":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void AddStudent()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Grade (A, B, C, etc.): ");
        char grade = Console.ReadLine()[0];

        Console.Write("Enter GPA (0.0 - 4.0): ");
        float gpa = float.Parse(Console.ReadLine());

        Console.Write("Is Student Passed? (true/false): ");
        bool isPassed = bool.Parse(Console.ReadLine());

        string studentData = $"Name: {name}, Age: {age}, Grade: {grade}, GPA: {gpa:F2}, Passed: {isPassed}\n";

        File.AppendAllText("students.txt", studentData);

        Console.WriteLine("\nStudent added successfully!");
    }

    private static void ViewStudents()
    {
        if (File.Exists("students.txt"))
        {
            Console.WriteLine("\n===== Student List =====");
            string data = File.ReadAllText("students.txt");
            Console.WriteLine(data);
        }
        else
        {
            Console.WriteLine("No student records found.");
        }
    }
}
