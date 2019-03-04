using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCalculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[0];
            int a = 0;
            while (true)
            {
                Console.WriteLine("Enter the operation: ");
                string operation = Console.ReadLine();
                if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                {
                    Console.WriteLine("Input numbers: ");
                    int firstNum;
                    int secondNum;
                    bool isFirstNum = int.TryParse(Console.ReadLine(), out firstNum);
                    bool isSecondNum = int.TryParse(Console.ReadLine(), out secondNum);

                    if (isFirstNum && isSecondNum)
                    {
                        double result = 0;
                        switch (operation)
                        {
                            case "+":
                                result = firstNum + secondNum;
                                break;
                            case "-":
                                result = firstNum - secondNum;
                                break;
                            case "*":
                                result = firstNum * secondNum;
                                break;
                            case "/":
                                if (secondNum == 0)
                                {
                                    Console.WriteLine("you can not divide with zero");
                                    break;
                                }
                                result = firstNum / Convert.ToDouble(secondNum);
                                break;
                        }
                        Console.WriteLine("result is: " + result);
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[a] = Convert.ToString(firstNum) + operation + Convert.ToString(secondNum) + "=" + result;
                        a++;

                        Console.WriteLine("Do you want another calculation? enter Y/N");
                        if (Console.ReadLine().ToLower() == "n")
                        {
                            Console.WriteLine("Calculation history");
                            foreach (var item in arr)
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
                        Console.WriteLine("you entered invalid numbers, please try again");
                }
                else
                    Console.WriteLine("You entered unvalid operation! Please try again");
            }
            Console.ReadLine();
        }
    }
}
