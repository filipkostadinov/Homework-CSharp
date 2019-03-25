using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = ListOfUsers();


            //var admin1 = new Admin("adminuser1", "adminpass1");
            //var admin2 = new Admin("adminuser2", "adminpass2");
            //var admins = new List<Admin>() { admin1, admin2};

            //var trainer1 = new Trainer("traineruser1", "trainerpass1");
            //var trainer2 = new Trainer("traineruser2", "trainerpass2");
            //var trainers = new List<Trainer>() { trainer1, trainer2 };

            //var student1 = new Student("studentuser1", "studentpass1");
            //var student2 = new Student("studentuser2", "studentpass2");
            //var students = new List<Student>() { student1, student2 };

            //List<User> users = new List<User>();
            //users.AddRange(admins);
            //users.AddRange(trainers);
            //users.AddRange(students);

            Console.WriteLine("Please login");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            User user;

            user = users.Where(x => x.Username == username).FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine("there is no user like this");
            }

            if (user.Role == Role.Admin)
            {
                Console.WriteLine($"Hello {user.Username}");
                Console.WriteLine("Choose 1. Add user  2. Remove user");
                int addOrRemove = Convert.ToInt32(Console.ReadLine());

                if (addOrRemove == 1)
                {
                    Console.WriteLine("Which type of user you want to add: 1.Admin 2.Trainer 3.Student");
                    int typeOfUser = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter new username: ");
                    string newUsername = Console.ReadLine();
                    Console.Write("Enter new password: ");
                    string newPassword = Console.ReadLine();

                    if (typeOfUser == 1)
                    {
                        Admin newUser = new Admin(newUsername, newPassword);
                        users.Add(newUser);
                    }
                    else if (typeOfUser == 2)
                    {
                        Trainer newUser = new Trainer(newUsername, newPassword);
                        users.Add(newUser);
                    }
                    else if (typeOfUser == 3)
                    {
                        Student newUser = new Student(newUsername, newPassword);
                        users.Add(newUser);
                    }
                }
                else if (addOrRemove == 2)
                {
                    Console.WriteLine();
                    foreach (var item in users)
                    {
                        Console.WriteLine(item.Username);
                    }
                    Console.Write("Enter username you want to remove: ");
                    string userWantToRemove = Console.ReadLine();

                    User userRemove = users.Where(x => x.Username == userWantToRemove).FirstOrDefault();
                    users.Remove(userRemove);

                }
            }
            if (user.Role == Role.Trainer)
            {
                Console.WriteLine(user.GetType());

                Console.WriteLine("1.Show all students  2.Show all subjects ");
                int trainerInput = Convert.ToInt32(Console.ReadLine());

                if (trainerInput == 1)
                {
                    List<User> allStudents = users.Where(x => x.Role == Role.Student).ToList();
                    foreach (var item in allStudents)
                    {
                        Console.WriteLine(item.Username);
                    }

                    Console.WriteLine("Show a student's info");
                    Console.Write("Student: ");
                    string studentInput = Console.ReadLine();
                    User student = allStudents.Where(x => x.Username == studentInput).FirstOrDefault();

                    //foreach (var item in student.Subjects)
                    //{
                    //    Console.WriteLine(item.Grade);
                    //}

                }
                else if (trainerInput == 2)
                {
                    List<Subject> allSubjects = ListOfSubjects();

                    foreach (var item in allSubjects)
                    {
                        Console.WriteLine($"{item.Name} / listening : {item.StudentsListen.Count}");
                    }
                }
            }
            if (user.Role == Role.Student)
            {

            }

        }

        public static List<Subject> ListOfSubjects()
        {
            return new List<Subject>()
            {
                new Subject("Basic Programming Principles"),
                new Subject("HTML"),
                new Subject("CSS"),
                new Subject("Basic JavaScript"),
                new Subject("Advanced Javascript"),
                new Subject("Basic C#"),
                new Subject("Advanced C#"),
                new Subject("Database Development"),
            };
        }

        public static List<User> ListOfUsers()
        {
            return new List<User>()
            {
                new Admin("admin1", "admin1"),
                new Admin("admin2", "admin2"),

                new Trainer("trainer1", "trainer1"),
                new Trainer("trainer2", "trainer2"),

                new Student("student1", "student1"),
                new Student("student2", "student2")
            };
        }
    }
}
