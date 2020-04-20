using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInfo
{
    public class StudentData
    {
        HashSet<Student> data;

        public StudentData()
        {
            this.data = new HashSet<Student>();
        }

        public HashSet<Student> Data { get; set; }

        public void CreateStudnet(Student student)
        {
            this.data.Add(student);
        }

        public Student Show(string name)
        {
            return this.data.FirstOrDefault(x => x.Name == name);

        }


    }
}
