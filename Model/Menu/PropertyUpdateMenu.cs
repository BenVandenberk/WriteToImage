using System.Collections.Generic;
using System.Reflection;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.Reflection;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    /// <summary>
    /// Note that reflection is used to fill out the specifics of this menu. Exceptions of type BReflectionException 
    /// are thrown if the any reflect operation fails to obtain a result due to missconfiguration of 
    /// the class of type T
    /// </summary>
    /// <typeparam name="T">The type of Class for which the menu enables modification</typeparam>
    public class PropertyUpdateMenu<T> : AbstractProgrammaMenu where T : IBClass
    {
        private const string PLACEHOLDER = "£";
        private const string TITEL_TEMPLATE = "*** Pas £ gegevens aan ***";

        public PropertyUpdateMenu() : base(TITEL_TEMPLATE, new List<string>()) {
            Configure();
        }

        private void Configure() {
            // Menu title (=~ class type)
            string typeName =
                HelpMe.AttributeStringData(this.GetType().GenericTypeArguments[0], typeof(BClass), "Description");
            this.Titel = TITEL_TEMPLATE.Replace(PLACEHOLDER, typeName);

            // Menu options (=~ class properties)
        }
    }
}