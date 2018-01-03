using System;
using System.Collections.Generic;
using System.Linq;
using Practicum13_Ben;

namespace SchrijvenOpAfbeelding
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
                case CrudKeuze.CREATE.index:
                    break;
            }
        }
    }
}