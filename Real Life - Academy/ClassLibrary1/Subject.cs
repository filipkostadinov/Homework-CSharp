using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Subject
    {
        public string Name { get; set; }
        public List<Student> StudentsListen { get; set; } = new List<Student>();
        public int Grade { get; set; }

        public Subject(string name)
        {
            Name = name;
        }

        //public void ShowGrades(Subject subject)
        //{
        //    Console.WriteLine(subject.Grade);
        //}
    }
}
