using System;
using System.Collections.Generic;
using System.Linq;

namespace SchrijvenOpAfbeelding.BConsole
{
    public static class HelpMe
    {
        public static T ChooseFromList<T>(List<T> list) {
            for (int i = 1; i <= list.Count(); i++) {
                System.Console.WriteLine($"{i}. {list.ElementAt(i - 1)}");
            }

            return list.ElementAt(AskForIntInput(1, list.Count) - 1);
        }

        public static int AskForIntInput(int lowerBoundInclusive, int upperBoundInclusive) {
            return AskForIntInput("Kies", lowerBoundInclusive, upperBoundInclusive);
        }

        public static int AskForIntInput(string message, int lowerBoundInclusive, int upperBoundInclusive) {
            int choice = int.MinValue;

            do {
                System.Console.Write($"{message} [{lowerBoundInclusive} - {upperBoundInclusive}]: ");
                if (!Int32.TryParse(System.Console.ReadLine(), out choice) || OutOfBounds(choice, lowerBoundInclusive, upperBoundInclusive)) {
                    System.Console.WriteLine("Geen geldige keuze...");
                }
            } while (OutOfBounds(choice, lowerBoundInclusive, upperBoundInclusive));

            return choice;
        }

        public static string AskForStringInput(string message)
        {
            System.Console.Write(message);
            return System.Console.ReadLine();
        }

        public static void AnyInputToContinue()
        {
            System.Console.WriteLine("Druk op een toets om verder te gaan");
            System.Console.ReadLine();
        }

        private static bool OutOfBounds(int toTest, int lowerInclusive, int upperInclusive) {
            return toTest < lowerInclusive || toTest > upperInclusive;
        }
    }
}
