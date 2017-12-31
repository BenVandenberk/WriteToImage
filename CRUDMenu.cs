using System.Collections.Generic;
using Practicum13_Ben;

namespace SchrijvenOpAfbeelding
{
    public class CRUDMenu<T> : ProgrammaMenu
    {
        private const string AANPASSEN = "Aanpassen";
        private const string VERWIJDEREN = "Verwijderen";
        private const string AANMAKEN = "Aanmaken";
        private const string LIJST = "Lijst tonen";

        public CRUDMenu(string entityName) : base($"*** Aanpassen van {entityName} ***", new []{LIJST, AANMAKEN, AANPASSEN, VERWIJDEREN}) {
        }
    }
}