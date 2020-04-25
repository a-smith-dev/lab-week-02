﻿using System;
using System.Collections.Generic;

namespace Lab_Week_02
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Welcome to the Grand Circus Casino! Roll the dice? (y/n): ");
            var response = ValidateYesNo(Console.ReadLine());
            var counter = 1;
            while (response == "y")
            {
                Console.Write("How many sides should each die have? ");
                int sides = ValidateNumber(Console.ReadLine());
                Console.WriteLine($"\nRoll {counter}:");
                var die1 = Roll(sides);
                var die2 = Roll(sides);
                CheckRolls(die1, die2);
                Console.Write("\nRoll again? (y/n): ");
                response = ValidateYesNo(Console.ReadLine());
                counter++;
            }
            Console.WriteLine("\nThank you for playing!");
        }

        public static string ValidateYesNo(string response)
        {
            while (response.ToLower() != "y" && response.ToLower() != "n")
            {
                Console.Write("Please enter y or n: ");
                response = Console.ReadLine();
            }
            return response.ToLower();
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
        public static int Roll(int sides)
        {
            var random = new Random();
            var result = random.Next(1, sides + 1);
            Console.WriteLine(result);
            return result;
        }
        public static void CheckRolls(int die1, int die2)
        {
            var sum = die1 + die2;
            string message;
            var rollResults = new Dictionary<int, string>()
            {
                {2, "Snake Eyes!"},
                {3, "Craps!"},
                {7, "Natural!"},
                {11, "Natural!"},
                {12, "Box Cars!"}
            };
            if (rollResults.TryGetValue(sum, out message))
            {
                Console.WriteLine(message);
            }
        }
    }
}
