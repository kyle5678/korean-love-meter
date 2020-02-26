using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Korean_Love_Meter_Thing
{
    class Program
    {
        static bool startup = false;

        static string[] To1 = new string[] { "A", "K", "U" };
        static string[] To2 = new string[] { "B", "L", "V" };
        static string[] To3 = new string[] { "C", "M", "W" };
        static string[] To4 = new string[] { "D", "N", "X" };
        static string[] To5 = new string[] { "E", "O", "Y" };
        static string[] To6 = new string[] { "F", "P", "Z" };
        static string[] To7 = new string[] { "G", "Q" };
        static string[] To8 = new string[] { "H", "R" };
        static string[] To9 = new string[] { "I", "S" };
        static string[] To0 = new string[] { "J", "T" };

        static void Main(string[] args)
        {
            for (; ; )
            {
                try
                {
                    // Startup Message
                    if (startup == false)
                    {
                        Console.WriteLine("Welcome to the Korean Love Meter Thing.... (ask mummy)");
                        startup = true;
                    }

                    // Input
                    for (; ; )
                    {
                        string input = Ask("Input 2 names together (all caps), or 'exit': ");

                        if (input == "exit")
                            Environment.Exit(0);
                        else if (input == "")
                            Console.WriteLine("Invalid Input: empty");
                        else
                        {
                            // Functionality
                            List<string> Names = new List<string>();
                            foreach (char letter in input)
                            {
                                Names.Add(letter.ToString());
                            }

                            bool exit = false;

                            List<int> NameNums = new List<int>();
                            foreach (string letter in Names)
                            {
                                if (exit)
                                    break;

                                if (Array.Exists(To1, e => e == letter))
                                    NameNums.Add(1);
                                else if (Array.Exists(To2, e => e == letter))
                                    NameNums.Add(2);
                                else if (Array.Exists(To3, e => e == letter))
                                    NameNums.Add(3);
                                else if (Array.Exists(To4, e => e == letter))
                                    NameNums.Add(4);
                                else if (Array.Exists(To5, e => e == letter))
                                    NameNums.Add(5);
                                else if (Array.Exists(To6, e => e == letter))
                                    NameNums.Add(6);
                                else if (Array.Exists(To7, e => e == letter))
                                    NameNums.Add(7);
                                else if (Array.Exists(To8, e => e == letter))
                                    NameNums.Add(8);
                                else if (Array.Exists(To9, e => e == letter))
                                    NameNums.Add(9);
                                else if (Array.Exists(To0, e => e == letter))
                                    NameNums.Add(0);
                                else
                                {
                                    Console.WriteLine("Invalid input: invalid characters");
                                    exit = true;
                                }
                            }

                            if (exit)
                                break;

                            for (int o = 0; NameNums.Count > 2; o++)
                            {
                                for (int a = 0; a < o; a++)
                                    Console.Write(" ");
                                foreach (int x in NameNums)
                                {
                                    Console.Write("{0} ", x);
                                }
                                Console.WriteLine();

                                List<int> NewlineNameNums = new List<int>();
                                for (int i = 1; i < NameNums.Count; i++)
                                {
                                    int newNum = NameNums[i - 1] + NameNums[i];
                                    if (newNum >= 10)
                                    {
                                        newNum -= 10;
                                    }
                                    NewlineNameNums.Add(newNum);
                                }
                                NameNums = NewlineNameNums;
                            }
                            Console.WriteLine("{0} loves each other {1}{2}%!", input, NameNums[0], NameNums[1]);
                        }
                    }
                }

                catch (Exception e)
                {
                    // Exception

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Something went wrong...");
                    Console.WriteLine(e);
                    Console.WriteLine("For your convenience, we will restart the program for you.");

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        static string Ask(string question = "")
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}
