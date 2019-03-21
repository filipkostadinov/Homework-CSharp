using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Classes
{
    public class Product
    {        
        public string Name;
        public int SerialNumber;
        public string Description;
        public string Declaration;

        public Product(string name, int serialNumber, string description)
        {
            Name = name;
            SerialNumber = serialNumber;
            Description = description;
        }
    }
}
