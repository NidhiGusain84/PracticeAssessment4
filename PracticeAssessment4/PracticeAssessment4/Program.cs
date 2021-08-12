using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeAssessment4
{
    class Program
    {
        static void Main(string[] args)
        {
            string response;

            List<int> scoresNidhi = new List<int>() { 80, 90, 95 };
            List<int> scoresLaksh = new List<int>() { 70, 87, 90 };
            List<int> scoresTammy = new List<int>() { 80, 65, 79 };
            List<int> scoresSirisha = new List<int>() { 99, 97, 95 };
            

            List<Student> rosterStudents = new List<Student>()
            {
                new Student("Nidhi", 1, scoresNidhi),
                new Student("Laksh", 1, scoresLaksh),
                new Student("Tammy", 1, scoresTammy)
            };

            

            GradStudent gradStudent = new GradStudent("Sirisha", 2, scoresSirisha, rosterStudents);

            List<Student> allStudents = new List<Student>(rosterStudents)
            {
                gradStudent
            };

            while (true)
            {

                Console.Write("To log in enter your name: ");
                string name = Console.ReadLine();

                foreach (var student in allStudents)
                {
                    if (student.Name.ToLower() == name.ToLower())
                    {

                        if (student.Status == 1)
                        {
                            //print student menu
                            PrintStudentMenu(student);
                            Console.WriteLine("\nWould you like to return to the login? (y/n)?");
                            string choice = Console.ReadLine();
                            if (choice == "y")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Goodbye!");
                                return;
                            }
                        }
                        else
                        {
                            //print GradStudent menu
                            Console.WriteLine("Would you like to score a student (a)? or see a report card? (b)");
                            response = Console.ReadLine().ToLower();
                            if (response == "a")
                            {
                                Console.WriteLine("Who would you like to score?");
                                string stuName = Console.ReadLine();                                                              
                                
                                //  Student found1 = rosterStudents.Where(x => x.Name.ToLower() == stuName.ToLower()).FirstOrDefault();
                                Student found = rosterStudents.Find(x => x.Name.ToLower() == stuName.ToLower());
                                if(found != null)
                                {
                                    Console.WriteLine($"What score would you like to assign {stuName}?");
                                    int.TryParse(Console.ReadLine(), out int stuScore);
                                    GradStudent.ScoreAStudent(found, stuScore);
                                    Console.WriteLine($"{stuScore} was added for {stuName}");
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input.");
                                }

                                                            
                               
                                Console.WriteLine("Would you like to return to the login? (y/n)?");
                                string choice = Console.ReadLine();
                                if (choice == "y")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Goodbye!");
                                    return;
                                }

                            }
                            else
                            {
                                foreach (var s in allStudents)
                                {
                                    PrintStudentMenu(s);
                                    Console.WriteLine();
                                }

                                Console.WriteLine("Would you like to return to the login? (y/n)?");
                                string choice = Console.ReadLine();
                                if (choice == "y")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Goodbye!");
                                    return;
                                }
                            }
                        }
                    }
                    
                }
               

            }
            Console.WriteLine("Wrong input.");
        }

       public static void PrintStudentMenu(Student s)
        {
            Console.Write($"Name: {s.Name}, Scores: ");
            foreach (var score in s.Scores)
            {
                Console.Write(score + " ");

            }
            Console.Write($", Grade: {s.GetGrade()}");
        }

       


    }
}
