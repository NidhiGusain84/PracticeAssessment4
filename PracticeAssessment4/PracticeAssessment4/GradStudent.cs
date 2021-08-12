using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAssessment4
{
    class GradStudent : Student
    {
        public List<Student> MyStudentsList;

        public GradStudent(string name, int status, List<int> scores, List<Student> myStudentsList) : base(name, status, scores)
        {
            MyStudentsList = myStudentsList;

        }

        //todo test code 
        public override char GetGrade()
        {          
            int tally = 0;

            foreach (Student s in MyStudentsList)
            {
                s.Grade = base.GetGrade();

                if (s.Grade == 'a')
                {
                    tally = tally + 10;
                }
                else if (s.Grade == 'b')
                {
                    tally = tally + 9;
                }
                else if (s.Grade == 'c')
                {
                    tally = tally + 8;
                }
                else if (s.Grade == 'd')
                {
                    tally = tally + 7;
                }
            }
                int avg = tally / MyStudentsList.Count;

                if((Grade == 'a' || Grade == 'b' || Grade == 'c') && avg>=7)
                {
                    this.Grade = 'a';                    
                }
                else
                {
                    this.Grade = 'e';                   
                }
            
            return this.Grade;
        }

        public static void ScoreAStudent(Student s, int score)
        {
            s.Scores.Add(score);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Scores: {Scores}, Grade: {Grade}";
        }

    }
}
