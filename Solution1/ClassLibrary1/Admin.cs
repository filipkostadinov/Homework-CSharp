using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Admin : User
    {
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
            Role = Role.Admin;
        }

        //public void AddUser(User user, List<User> users)
        //{
        //    if (Username == user.Username)
        //        users.Add(user);
        //}

        //public void RemoveUser(User user, List<User> users)
        //{
        //    if (Username == user.Username)
        //        users.Remove(user);
        //}
    }
}
