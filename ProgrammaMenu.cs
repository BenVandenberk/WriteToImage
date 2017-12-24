using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum13_Ben
{
    public class ProgrammaMenu
    {
        private int keuze;

        public string Titel { get; set; }
        public List<string> MenuOpties { get; set; }
        public int Keuze
        {
            get {
                return this.keuze;
            }
        }

        public ProgrammaMenu(string titel, IEnumerable<string> menuOpties)
        {
            this.Titel = titel;
            this.MenuOpties = new List<string>(menuOpties);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Titel);
            sb.Append(Environment.NewLine);

            for (int i = 1; i <= MenuOpties.Count; i++)
            {
                sb.Append(String.Format("{0}. {1}", i, MenuOpties.ElementAt(i - 1)));
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public void Kies()
        {
            while(!(Int32.TryParse(Console.ReadLine(), out keuze) && Keuze > 0 && Keuze <= MenuOpties.Count))
            {
                Console.WriteLine("Ongeldige menukeuze");
            }
        }
    }
}
