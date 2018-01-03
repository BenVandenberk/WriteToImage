using System.Collections.Generic;
using System.Linq;

namespace SchrijvenOpAfbeelding.BConsole
{
    public class CrudMenu<T> : ProgrammaMenu
    {
        private const string AANPASSEN = "Aanpassen";
        private const string VERWIJDEREN = "Verwijderen";
        private const string AANMAKEN = "Aanmaken";
        private const string LIJST = "Lijst tonen";
        private const string TERUG = "Terug";

        public List<T> List { get; set; }

        public CrudMenu(string entityName, List<T> list) : base($"*** Aanpassen van {entityName} ***", CrudKeuze.Values.Select(k => k.Description)) {
            this.List = list;
        }

        public override void Kies() {
            base.Kies();

            switch (this.Keuze) {
                case (int)CrudKeuze.CrudEnum.Create:
                    break;
            }
        }
    }
}