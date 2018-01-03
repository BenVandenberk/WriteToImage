using System.Collections.Generic;
using System.Linq;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    public class CrudMenu<T> : ConsoleProgrammaMenu
    {
        public List<T> List { get; set; }

        public CrudMenu(string entityName, List<T> list) : base($"*** Aanpassen van {entityName} ***", CrudKeuze.Values.Select(k => k.Description)) {
            this.List = list;
        }

        public override void Kies() {
            base.Kies();

            switch (this.Keuze) {
                case (int)CrudKeuze.CrudEnum.Create:
                    break;
                case (int)CrudKeuze.CrudEnum.Update:
                    break;
                case (int)CrudKeuze.CrudEnum.Delete:
                    break;
                case (int)CrudKeuze.CrudEnum.List:
                    break;
                case (int)CrudKeuze.CrudEnum.Return:
                    break;
            }
        }
    }
}