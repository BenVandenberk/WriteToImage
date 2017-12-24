using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practicum13_Ben;

namespace SchrijvenOpAfbeelding
{
    public class Controller
    {
        private const string TITEL = "*** Apo Hax ***";
        private const string AFBEELDING_INSTELLEN = "Nieuwe afbeelding instellen";
        private const string TEKSJES_INSTELLEN = "Een tekstje instellen voor een afbeelding";
        private const string STOP = "Stop het programma";
        
        private ProgrammaMenu programmaMenu;
        private List<Afbeelding> afbeeldingen;
        private List<Tekst> tekstjes;
        private Schrijver schrijver;

        public Controller() {
            this.programmaMenu = new ProgrammaMenu(TITEL, new List<string>() {AFBEELDING_INSTELLEN, TEKSJES_INSTELLEN, STOP});
            this.afbeeldingen = new List<Afbeelding>();
            this.tekstjes = new List<Tekst>();
            this.schrijver = new Schrijver(new Font("Calibri", 26), Brushes.Black, @"C:\Users\Ben\Desktop");
        }

        public void run() {
            do {
                Console.Clear();
                Console.WriteLine(this.programmaMenu);
                this.programmaMenu.Kies();

                switch (this.programmaMenu.Keuze) {
                    case 1:
                        string naam = askForStringInput("Geef een naam aan de afbeelding: ");
                        string path = askForStringInput("Geef het absolute pad naar de afbeelding in: ");
                        this.afbeeldingen.Add(new Afbeelding(path, naam));
                        break;
                    case 2:

                        break;
                    default:
                        break;
                }
            } while (this.programmaMenu.Keuze != 3);
        }

        private string askForStringInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private void anyInputToContinue()
        {
            Console.WriteLine("Druk op een toets om verder te gaan");
            Console.ReadLine();
        }
    }
}
