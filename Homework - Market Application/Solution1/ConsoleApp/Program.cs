using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Classes;

namespace ConsoleApp
{
    class Program
    {
        static void MakePerson(Person person)
        {
            Console.WriteLine("Enter name");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Last name");
            person.LastName = Console.ReadLine();
            Console.WriteLine("date of birth");
            person.DateOfBirth = DateTime.Parse(Console.ReadLine());
            person.SSN = new Random().Next(10000,99999);
        }

        static void Main(string[] args)
        {
            Product[] products = 
            {
            new Product("milk", new Random().Next(10000, 99999), "cow milk"),
            new Product("eggs", new Random().Next(10000, 99999), "chicken eggs"),
            new Product("flour", new Random().Next(10000, 99999), "bread flour")
            };
            
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{products[i].Name} " +
                    $"{products[i].SerialNumber} " +
                    $"{products[i].Description} " +
                    $"{products[i].Declaration}");
            }

            Person buyer = new Person();
            Console.WriteLine("enter the prop for the buyer");
            MakePerson(buyer);

            Person cashier = new Person();
            Console.WriteLine("enter the prop for the cashier");
            MakePerson(cashier);

            while (true)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + products[i]);
                }
            }


        }
    }
}
