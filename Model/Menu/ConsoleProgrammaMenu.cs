using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    public class ConsoleProgrammaMenu : AbstractProgrammaMenu
    {
        private int keuze;
        public int Keuze => this.keuze;

        public ConsoleProgrammaMenu(string titel, IEnumerable<string> menuOpties) : base(titel, menuOpties)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Titel);
            sb.Append(Environment.NewLine);

            for (int i = 1; i <= this.MenuOpties.Count; i++)
            {
                sb.Append($"{i}. {this.MenuOpties.ElementAt(i - 1)}");
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public virtual void Kies()
        {
            while(!(Int32.TryParse(System.Console.ReadLine(), out this.keuze) && this.Keuze > 0 && this.Keuze <= this.MenuOpties.Count))
            {
                System.Console.WriteLine("Ongeldige menukeuze");
            }
        }
    }
}
