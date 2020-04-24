﻿using System;

namespace Lab_Week_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the Grand Circus Casino! Roll the dice? (y/n): ");
            var response = ValidateYesNo(Console.ReadLine().ToLower());
            var counter = 1;
            int size;
            while (response == "y")
            {
                Console.Write("How many sides should each die have? ");
                size = ValidateNumber(Console.ReadLine());

                Console.WriteLine($"Roll {counter}:");
                Roll(size);
                Roll(size);

                Console.Write("Roll again? (y/n): ");
                response = ValidateYesNo(Console.ReadLine().ToLower());
                counter++;
            }
            Console.WriteLine("Thank you for playing!");
        }

        private static string ValidateYesNo(string response)
        {
            while(response != "y" && response != "n")
            {
                Console.Write("Please enter y or n: ");
                response = Console.ReadLine().ToLower();
            }
            return response;
        }
        public static int ValidateNumber(string response)
        {
            var number = -1;
            while(!int.TryParse(response, out number) || number < 1)
            {
                Console.Write("Please enter a positive integer: ");
                response = Console.ReadLine();
            }
            return number;
        }
        public static void Roll(int size)
        {
            var random = new Random();
            Console.WriteLine(random.Next(1, size));
        }
    }
}