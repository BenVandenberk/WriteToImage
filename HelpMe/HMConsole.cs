using System;
using System.Collections.Generic;
using System.Linq;

namespace SchrijvenOpAfbeelding.HelpMe
{
    public class HmConsole
    {
        private static HmConsole single;

        public static HmConsole Single => single ?? (single = new HmConsole());
        private HmConsole() {
            
        }

        public T ChooseFromList<T>(List<T> list) {
            for (int i = 1; i <= list.Count(); i++) {
                System.Console.WriteLine($"{i}. {list.ElementAt(i - 1)}");
            }

            return list.ElementAt(AskForIntInput(1, list.Count) - 1);
        }

        public int AskForIntInput(int lowerBoundInclusive, int upperBoundInclusive) {
            return AskForIntInput("Kies", lowerBoundInclusive, upperBoundInclusive);
        }

        public int AskForIntInput(string message, int lowerBoundInclusive, int upperBoundInclusive) {
            int choice = int.MinValue;

            do {
                System.Console.Write($"{message} [{lowerBoundInclusive} - {upperBoundInclusive}]: ");
                if (!Int32.TryParse(System.Console.ReadLine(), out choice) || OutOfBounds(choice, lowerBoundInclusive, upperBoundInclusive)) {
                    System.Console.WriteLine("Geen geldige keuze...");
                }
            } while (OutOfBounds(choice, lowerBoundInclusive, upperBoundInclusive));

            return choice;
        }

        public string AskForStringInput(string message)
        {
            System.Console.Write(message);
            return System.Console.ReadLine();
        }

        public void AnyInputToContinue()
        {
            System.Console.WriteLine("Druk op een toets om verder te gaan");
            System.Console.ReadLine();
        }

        private bool OutOfBounds(int toTest, int lowerInclusive, int upperInclusive) {
            return toTest < lowerInclusive || toTest > upperInclusive;
        }
    }
}
