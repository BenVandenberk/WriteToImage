using System;
using System.Collections.Generic;
using System.Dynamic;

namespace SchrijvenOpAfbeelding
{
    public class CrudKeuze
    {
        public static readonly CrudKeuze CREATE = new CrudKeuze(CrudEnum.Create, "Aanmaken");
        public static readonly CrudKeuze UPDATE = new CrudKeuze(CrudEnum.Update, "Aanpassen");
        public static readonly CrudKeuze DELETE = new CrudKeuze(CrudEnum.Delete, "Verwijderen");
        public static readonly CrudKeuze LIST = new CrudKeuze(CrudEnum.List, "Lijst");
        public static readonly CrudKeuze RETURN = new CrudKeuze(CrudEnum.Return, "Terug");

        public static IEnumerable<CrudKeuze> Values {
            get {
                yield return CREATE;
                yield return UPDATE;
                yield return DELETE;
                yield return LIST;
                yield return RETURN;
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
            Create, Update, Delete, List, Return
        }
    }

}
