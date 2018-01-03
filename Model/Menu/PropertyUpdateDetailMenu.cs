using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.ExtensionMethods;
using SchrijvenOpAfbeelding.Reflection;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    public class PropertyUpdateDetailMenu : ConsoleProgrammaMenu
    {
        private const string PLACEHOLDER = "£";
        private const string TITEL_TEMPLATE = "*** Aanpassen £ ***";

        public BProperty BPropertyAttr { get; }
        public string Old { get; }
        public PropertyInfo Property { get; }
        public Object Obj { get; }

        public PropertyUpdateDetailMenu(PropertyInfo property, Object obj) : base(TITEL_TEMPLATE, new List<string>()) {
            this.BPropertyAttr = HelpMe.AttributeOfType<BProperty>(property);
            this.Titel = TITEL_TEMPLATE.Replace(PLACEHOLDER, this.BPropertyAttr.Description);
            this.Property = property;
            this.Obj = obj;
            this.Old = HelpMe.PropertyValueString(obj, property);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.HorizontalSplit()
                .Append($"Huidige waarde: {this.Old}")
                .NewLine()
                .Append("Nieuwe waarde: ");

            return sb.ToString();
        }
    }
}