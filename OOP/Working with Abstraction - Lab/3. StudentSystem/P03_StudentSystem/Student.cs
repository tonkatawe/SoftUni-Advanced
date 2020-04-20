using System.Text;

namespace StudentInfo
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string name;
        private int age;
        private double grade;

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public double Grade { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }
        public override string ToString()
        {
            var result = new StringBuilder();

            string gradeComment = GradeComment();
            result.AppendLine($"{this.Name} is {this.Age} years old. {gradeComment}");
            return result.ToString().TrimEnd();
        }

        public string GradeComment()
        {
            if (this.Grade >= 5)
            {
                return "Excellent student.";
            }
            else if (this.Grade >= 3.50)
            {
                return "Average student.";
            }
            else
            {
                return "Very nice person.";
            }
        }
    }
}



