using System.Collections.Generic;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    public class CrudKeuze
    {
        public static readonly CrudKeuze Create = new CrudKeuze(CrudEnum.Create, "Aanmaken");
        public static readonly CrudKeuze Update = new CrudKeuze(CrudEnum.Update, "Aanpassen");
        public static readonly CrudKeuze Delete = new CrudKeuze(CrudEnum.Delete, "Verwijderen");
        public static readonly CrudKeuze List = new CrudKeuze(CrudEnum.List, "Lijst");
        public static readonly CrudKeuze Return = new CrudKeuze(CrudEnum.Return, "Terug");

        public static IEnumerable<CrudKeuze> Values {
            get {
                yield return Create;
                yield return Update;
                yield return Delete;
                yield return List;
                yield return Return;
            }
        }

        public CrudEnum Index { get; set; }
        public string Description { get; set; }
        
        CrudKeuze(CrudEnum index, string description) {
            this.Index = index;
            this.Description = description;
        }

        public override string ToString() {
            return this.Description;
        }

        public enum CrudEnum {
            Create = 1, Update = 2, Delete = 3, List = 4, Return = 5
        }
    }

}
