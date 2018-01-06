using System;
using System.Collections.Generic;
using System.Drawing;
using SchrijvenOpAfbeelding.BConsole;
using SchrijvenOpAfbeelding.Model;
using SchrijvenOpAfbeelding.Model.Core;
using SchrijvenOpAfbeelding.Model.Menu;

namespace SchrijvenOpAfbeelding.Program
{
    public class Controller
    {
        private const string TITEL = "*** Apo Hax ***";
        private const string AFBEELDING_INSTELLEN = "Nieuwe afbeelding instellen";
        private const string TEKSJES_INSTELLEN = "Een tekstje instellen voor een afbeelding";
        private const string AFBEELDINGEN = "Afbeeldingen";
        private const string STOP = "Stop het programma";
        
        private ConsoleProgrammaMenu programmaMenu;
        private CrudMenu<Afbeelding> afbeeldingCrudMenu;
        private List<Afbeelding> afbeeldingen;
        private List<Tekst> tekstjes;
        private Schrijver schrijver;

        public Controller() {
            this.programmaMenu = new ConsoleProgrammaMenu(TITEL, new List<string>() {AFBEELDING_INSTELLEN, TEKSJES_INSTELLEN, AFBEELDINGEN, STOP});
            this.afbeeldingCrudMenu = new CrudMenu<Afbeelding>("Afbeelding", new List<Afbeelding>());
            this.afbeeldingen = new List<Afbeelding>();
            this.tekstjes = new List<Tekst>();
            this.schrijver = new Schrijver(new Font("Calibri", 26), Brushes.Black, @"C:\Users\Ben\Desktop");
        }

        public void Run() {
            do {
                Console.Clear();
                Console.WriteLine(this.programmaMenu);
                this.programmaMenu.Kies();

                switch (this.programmaMenu.Keuze) {
                    case 1:
                        string naam = HelpMe.AskForStringInput("Geef een naam aan de afbeelding: ");

                        bool geldigeAfbeelding = false;
                        Bitmap bitmap = new Bitmap(1, 1);
                        string path;
                        do {
                            path = HelpMe.AskForStringInput("Geef het absolute pad naar de afbeelding in: ");

                            try {
                                bitmap = (Bitmap) Image.FromFile(path);
                                geldigeAfbeelding = true;
                            }
                            catch (Exception e) {
                                Console.WriteLine("Geen geldige afbeelding");
                                Console.WriteLine(e.Message);
                            }

                        } while (!geldigeAfbeelding);

                        //this.afbeeldingen.Add(new Afbeelding(path, naam, bitmap));
                        break;
                    case 2:
                        Afbeelding afbeelding = HelpMe.ChooseFromList(this.afbeeldingen);
                        Console.Clear();
                        Console.WriteLine($"Tekstje definiëren voor {afbeelding}");
                        Console.WriteLine(afbeelding.Afmetingen() + Environment.NewLine);

                        string teSchrijven =
                            HelpMe.AskForStringInput(
                                "Typ het tekstje dat je wilt schrijven op de afbeelding. Gebruik voor een nieuwe lijn volgende tekencombinatie: +*+");
                        int startPuntBreedte = HelpMe.AskForIntInput("Kies de startcoördinaat (BREEDTE)", 1, afbeelding.Bitmap.Width);
                        int startPuntHoogte = HelpMe.AskForIntInput("Kies de startcoördinaat (HOOGTE)", 1,
                            afbeelding.Bitmap.Height);

                        this.tekstjes.Add(new Tekst(afbeelding, new PointF(startPuntBreedte, startPuntHoogte), teSchrijven));
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine(this.afbeeldingCrudMenu.ToString());
                        this.afbeeldingCrudMenu.Kies();

                        break;
                    case 4:
                        Console.WriteLine("Het programma wordt afgesloten");
                        break;
                    default:
                        break;
                }

                HelpMe.AnyInputToContinue();
            } while (this.programmaMenu.Keuze != 4);
        }


    }
}
