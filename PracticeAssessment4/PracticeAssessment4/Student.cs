using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAssessment4
{
    class Student
    {
        public string Name;
        public int Status;
        public List<int> Scores;
        public char Grade;

        

        public Student(string name, int status, List<int> scores)
        {
            Name = name;
            Status = status;
            Scores = scores;
        }

        public virtual char GetGrade()
        {
            int sum = 0;
            foreach (int i in Scores)
            {               
                sum = sum + i;
            }
            int avg = sum / Scores.Count;

            if (avg >= 90)
            {
                Grade = 'a';
            }
            else if (avg >= 80)
            {
                Grade = 'b';
            }
            else if (avg >= 70)
            {
                Grade = 'c';
            }
            else if (avg >= 60)
            {
                Grade = 'd';
            }
            else
            {
                Grade = 'e';
            }
            return Grade;

        }

        public override string ToString()
        {
            return $"Name: {Name}, Scores: {Scores}, Grade: {Grade}";
        }


    }
}
