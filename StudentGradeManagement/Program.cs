/*
Student grade management system
To complete this challenge, you will need to create a console application to manage student grades. The system needs to be able to add students, add grades to different students, and calculate average grades for students. 

Some key features include:
1. Add new students with names and IDs.
2. Assign grades for different subjects.
3. Calculate the average grade for each student.
4. Display student records with their grades.
Each design challenge should require a similar amount of effort but will require two different approaches. Pick the one that interests you the most and start thinking about the code you might write to solve the problem. 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManagement
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Student Grade Management System!");
            var students = new List<Student>
            {
                new Student("Dude") { Grades = { 85, 90, 78 } },
                new Student("Pal") { Grades = { 88, 92, 80 } },
                new Student("Guy") { Grades = { 95, 85, 90 } }
            };
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        ViewStudents(students);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private static void ViewStudents(List<Student> students)
        {
            Console.WriteLine("\nStudent Records:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Average Grade: {student.CalculateAverage():F2}");
                Console.WriteLine("Grades: " + string.Join(", ", student.Grades));
            }
        }

        private static void AddStudent(List<Student> students)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            var newStudent = new Student(name);
            students.Add(newStudent);

            Console.WriteLine($"Student {name} with ID {newStudent.ID} added successfully!");
            int count = 0;
            while (count < 3)
            {
                Console.Write("Enter grade: ");
                double grade;
                while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
                {
                    Console.Write("Invalid grade. Please enter a number between 0 and 100: ");
                }
                newStudent.AddGrade(grade);
                Console.WriteLine($"Grade {grade} added for {name}.");
                count++;
            }
            System.Console.WriteLine("Added student and grades successfully!");
            System.Console.WriteLine("Here are the details of the new student:");
            // Display the new student's details
            Console.WriteLine($"Name: {newStudent.Name}, ID: {newStudent.ID}, Average Grade: {newStudent.CalculateAverage():F2}");
            Console.WriteLine("Grades: " + string.Join(", ", newStudent.Grades));
        }
    }

    internal class Student
    {
        public string Name { get; set; }
        private static int _idCounter = 1;
        public int ID { get; }
        public List<double> Grades { get; } = new List<double>();

        public Student(string name)
        {
            Name = name;
            ID = _idCounter++;
        }

        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }

        public double CalculateAverage()
        {
            return Grades.Count > 0 ? Grades.Average() : 0.0;
        }
    }
}