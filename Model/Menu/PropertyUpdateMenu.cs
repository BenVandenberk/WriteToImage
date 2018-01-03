using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.Reflection;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    /// <summary>
    /// Note that reflection is used to fill out the specifics of this menu. Exceptions of type BReflectionException 
    /// are thrown if the any reflect operation fails to obtain a result due to misconfiguration of 
    /// the class of type T
    /// </summary>
    /// <typeparam name="T">The type of Class for which the menu enables modification</typeparam>
    public class PropertyUpdateMenu<T> : ConsoleProgrammaMenu where T : IBClass
    {
        private const string PLACEHOLDER = "£";
        private const string TITEL_TEMPLATE = "*** Pas £ gegevens aan ***";

        private List<PropertyInfo> bProperties;
        private Dictionary<int, PropertyInfo> indexedBProperties;

        public CrudList<T> CrudList { get; set; }

        public PropertyUpdateMenu() : base(TITEL_TEMPLATE, new List<string>()) {
            Configure();
        }

        public PropertyUpdateMenu(CrudList<T> crudList) : base(TITEL_TEMPLATE, new List<string>()) {
            this.CrudList = crudList;
            Configure();
        }

        public override void Kies() {
            base.Kies();

            Console.Clear();
            Console.WriteLine(new PropertyUpdateDetailMenu(this.indexedBProperties[this.Keuze], ));
        }

        private void Configure() {
            // Type argument
            Type typeArgument = this.GetType().GenericTypeArguments[0];

            // Menu title (=~ class type)
            string typeName =
                HelpMe.AttributeStringData(typeArgument, typeof(BClass), "Description");
            this.Titel = TITEL_TEMPLATE.Replace(PLACEHOLDER, typeName);

            // Menu options (=~ class properties)
            this.bProperties = HelpMe.PropertiesWithBPropertyAttribute(typeArgument);
            this.MenuOpties = this.bProperties.Select(HelpMe.AttributeOfType<BProperty>)
                .Select(bProp => bProp.Description)
                .ToList();

            // Associate the order (=~ indexes shown to user) with right properties
            int startIndex = 1;
            this.bProperties.ForEach(prop => this.indexedBProperties.Add(startIndex++, prop));
        }
    }
}