using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            var length = Students.Count;
            var students = Students;
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int part = 1;
            int count = 0;
            while (count != Students.Count)
            {
                double studentGrade = Students[count].Grades[0];

                if (studentGrade == averageGrade)
                {
                    switch (part)
                    {
                        case 1:
                            return 'A';
                        case 2:
                            return 'B';
                        case 3:
                            return 'C';
                        case 4:
                            return 'D';
                        case 5:
                            return 'F';
                    }
                }
                part++;
                count++;
            }
            return '0';
        }
    }
}
