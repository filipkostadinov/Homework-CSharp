using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Trainer : User
    {
        //public List<Student> Students { get; set; } = new List<Student>();

        public Trainer(string username, string password)
        {
            Username = username;
            Password = password;
            Role = Role.Trainer;

        }

        public void ShowStudents(List<User> students)
        {
            foreach (var item in students)
            {
                Console.WriteLine(item.Username);
            }
        }

        public void ShowAllSubjects(List<Subject> subjects)
        {
            foreach (var item in subjects)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void ShowSubjectsWtihStudents(List<Subject> subjects)
        {
            int i = 0;
            foreach (var item in subjects)
            {
                Console.Write($"{item.Name} {item.StudentsListen[i].Username}");
                i++;
            }
        }
    }
}
