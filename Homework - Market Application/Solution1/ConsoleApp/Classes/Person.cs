using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Classes
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        public int SSN;
        public bool LoyalCard = false;  

        public void Introduce()
        {
            Console.WriteLine($"hi my name is {FirstName}");
        }
    }

}
