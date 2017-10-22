/*
 * Program.cs
 * This program allow user to enter the quantity of ticket for 3 seat sections and calculate the amount of income from those seats
 * 
 * Revision history:
 * Hoang Huu Tat Dat, 2017/05/30: Created
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stadium_w2
{
    class Program
    {
        //number of ticket of each section
        static int seatA;
        static int seatB;
        static int seatC;
        
        //income of ticket of each section
        static int incomeA;
        static int incomeB;
        static int incomeC;
        
        //total income
        static int total;
        
        //define if the user want to have new cycle or not
        static bool newCycle = true;


        static void Main(string[] args)
        {
            //After completing a cycle of calculating income, the application will ask user if they want to have a new cycle or not.
            //If user enter X, the program will quit. Any other key will start another cycle.
            while (newCycle == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                PrintRequest("A", out seatA);
                                break;
                            }
                        case 1:
                            {
                                PrintRequest("B", out seatB);
                                break;
                            }
                        case 2:
                            {
                                PrintRequest("C", out seatC);
                                break;
                            }
                    }
                }
                
                Calculation();
                PrintOut();
                Console.Write("Press any key to calculate another bill. Press X to exit." +
                    "\r\nYour selection: ");
                ConsoleKeyInfo ans = Console.ReadKey();
                if (ans.Key == ConsoleKey.X)
                {
                    newCycle = false;
                }
                Console.WriteLine("\r\n\n----------------------<>----------------------" +
                    "\r\n\n");
            }

        }


        /// <summary>
        /// Print out the current section that user are about to put in the quality of the seat
        /// Warning if user key in non-numeric value
        /// </summary>
        /// <param name="section">name of current section</param>
        /// <param name="quantity">pass out the quality of seat user require</param>
        /// 

        static void PrintRequest(string section, out int quantity)
        {
            bool temp = false;
            quantity = 0;
            while (temp == false)
            {
                Console.Write("Please type in the amount of seat at section " + section + ": ");
                string input = Console.ReadLine();
                if (CheckNumber(input))
                {
                    quantity = int.Parse(input);
                    temp = true;
                }
                else
                {
                    Console.WriteLine("----------------------WARNING----------------------");
                    Console.WriteLine("Only number is accepted.");
                    Console.WriteLine("----------------------------------------------------");
                }
            }
            
        }

        /// <summary>
        /// Check if the string value passed in is a number or not
        /// </summary>
        /// <param name="input">the value that need to be checked</param>
        /// <returns>True for number value, False for non-numeric value</returns>

        static bool CheckNumber(string input)
        {
            try
            {
                int.Parse(input);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Calculate the income of each seat section 
        /// </summary>

        static void Calculation()
        {
            incomeA = seatA * 15;
            incomeB = seatB * 12;
            incomeC = seatC * 19;
            total = incomeA + incomeB + incomeC;
        }

        /// <summary>
        /// Print out the income of every seat section and total incom
        /// </summary>
        
        static void PrintOut()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Income from {0} seat(s) of section A: ${1}",seatA, incomeA);
            Console.WriteLine("Income from {0} seat(s) of section B: ${1}", seatB, incomeB);
            Console.WriteLine("Income from {0} seat(s) of section C: ${1}", seatC, incomeC);
            Console.WriteLine("TOTAL: {0} seat(s), ${1}",seatA+seatB+seatC, total.ToString());
            Console.WriteLine("----------------------");
        }
    }
}
