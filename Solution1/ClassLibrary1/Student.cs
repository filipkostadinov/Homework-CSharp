using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Student : User
    {
        public Subject CurrentSubject { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public Student(string username, string password)
        {
            Username = username;
            Password = password;
            Role = Role.Student;
        }

        public void SubjectListen()
        {
            foreach (var item in Subjects)
            {
                Console.WriteLine($"Subject: {item.Name} Grade: {item.Grade}");
            }
        }
    }
}
