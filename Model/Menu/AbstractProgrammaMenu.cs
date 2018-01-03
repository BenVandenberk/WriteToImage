using System.Collections.Generic;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    public abstract class AbstractProgrammaMenu
    {
        public string Titel { get; set; }
        public List<string> MenuOpties { get; set; }

        protected AbstractProgrammaMenu(string title, IEnumerable<string> menuOpties) {
            this.Titel = title;
            this.MenuOpties = new List<string>(menuOpties);
        }
    }
}