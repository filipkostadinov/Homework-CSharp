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
            List<Subject> allSubjects = ListOfSubjects();
            List<Student> students = users.Where(x => x.Role == Role.Student).Cast<Student>().ToList();
            foreach (var item in students)
            {
                item.Subjects = ListOfSubjects();
            }

            //students[0].Subjects = new List<Subject>() { allSubjects[0], allSubjects[2], allSubjects[4], allSubjects[6] };
            //students[1].Subjects = new List<Subject>() { allSubjects[2], allSubjects[3], allSubjects[5], allSubjects[7] };
            //students[2].Subjects = new List<Subject>() { allSubjects[1], allSubjects[2], allSubjects[3], allSubjects[4] };
            //students[3].Subjects = new List<Subject>() { allSubjects[0], allSubjects[4], allSubjects[5], allSubjects[6] };
            //students[4].Subjects = new List<Subject>() { allSubjects[3], allSubjects[5], allSubjects[6], allSubjects[7] };
            
            //foreach (var student in students)
            //{
            //    var random = new Random();
            //    student.CurrentSubject = allSubjects[random.Next(0, allSubjects.Count - 1)];
            //}

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

            Console.WriteLine($"Hello {user.Username}");

            #region RoleAdmin
            if (user.Role == Role.Admin)
            {
                while (true)
                {
                    Console.WriteLine("Choose 1. Add user  2. Remove user 3.Logout");
                    int addOrRemove = Convert.ToInt32(Console.ReadLine());

                    if (addOrRemove == 1)
                    {
                        Console.WriteLine("Which type of user you want to add: 1.Admin 2.Trainer 3.Student");
                        int typeOfUser = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter new username: ");
                        string newUsername = Console.ReadLine();
                        Console.Write("Enter new password: ");
                        string newPassword = Console.ReadLine();

                        if (!CheckUser(users, newUsername))
                        {
                            Console.WriteLine("Already exist please try again");
                            typeOfUser = 0;
                        }
                        else if (typeOfUser == 1)
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
                            students.Add(newUser);
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

                        if (CheckUser(users, userWantToRemove))
                        {
                            User userRemove = users.Where(x => x.Username == userWantToRemove).FirstOrDefault();
                            foreach (var item in students)
                            {
                                if (item.Username == userRemove.Username)
                                    students.Remove(item);
                            }
                            users.Remove(userRemove);
                        }
                        else if (userWantToRemove == user.Username)
                        {
                            Console.WriteLine("Admins cant remove it self");
                        }
                        else
                            Console.WriteLine("Doesn't exist user like this");
                    }
                    else if (addOrRemove == 3)
                        break;
                }
            }
            #endregion

            #region RoleTrainer
            if (user.Role == Role.Trainer)
            {
                while (true)
                {
                    Console.WriteLine("1.Show all students  2.Show all subjects 3.Logout");
                    int trainerInput = Convert.ToInt32(Console.ReadLine());

                    if (trainerInput == 1)
                    {
                        foreach (var student in students)
                        {
                            Console.WriteLine(student.Username);
                        }

                        Console.WriteLine("Show a student's info");
                        Console.Write("Student: ");
                        string studentInput = Console.ReadLine();

                        if (CheckStudent(students, studentInput))
                        {
                            Student student = students.Where(x => x.Username == studentInput).FirstOrDefault();
                            foreach (var studentSubject in student.Subjects)
                            {
                                Console.WriteLine($"{studentSubject.Name} / {studentSubject.Grade}");
                            }
                        }
                    }
                    else if (trainerInput == 2)
                    {
                        foreach (var subject in allSubjects)
                        {
                            subject.StudentsListen = students.Where(x => x.CurrentSubject.Name == subject.Name).ToList();
                            Console.WriteLine($"{subject.Name} / listening : {subject.StudentsListen.Count}");
                        }
                    }
                    else if (trainerInput == 3)
                        break;
                }
            }
            #endregion

            if (user.Role == Role.Student)
            {

            }

        }

        public static bool CheckStudent(List<Student> students, string username)
        {
            foreach (var student in students)
            {
                if (student.Username == username)
                    return true;
            }
            return false;
        }

        public static bool CheckUser(List<User> users, string username)
        {
            foreach (var user in users)
            {
                if (user.Username == username)
                    return false;
            }
            return true;
        }

        public static List<Subject> ListOfSubjects()
        {
            var random = new Random();

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
                new Student("student2", "student2"),
                new Student("student3", "student3"),
                new Student("student4", "student4"),
                new Student("student5", "student5")
            };
        }
    }
}
