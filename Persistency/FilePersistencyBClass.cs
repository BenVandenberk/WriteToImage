using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.Model.Core;
using static SchrijvenOpAfbeelding.HelpMe.HelpMe;

namespace SchrijvenOpAfbeelding.Persistency
{
    public abstract class FilePersistencyBClass
    {
        protected const string DELIMITER = "\t";

        public string Path { get; }

        protected FilePersistencyBClass(string path) {
            this.Path = path;
        }

        protected string BClassFullyQualifiedFileName(IBClass bClass) {
            return $@"{this.Path}\\{BClassFileName(bClass)}";
        }

        protected string BClassFileName(IBClass bClass) {
            StringBuilder sb = new StringBuilder();
            sb.Append(HelpMeReflect.AttributeStringData(bClass.GetType(), typeof(BClass), "Description"));
            sb.Append(".txt");
            return sb.ToString();
        }

        protected string BClassToString(IBClass bClass) {
            List<PropertyInfo> properties = HelpMeReflect.PropertiesWithBPropertyAttribute(bClass.GetType());
            StringBuilder sb = new StringBuilder();
            
            foreach (PropertyInfo property in properties) {
                string propertyName = HelpMeReflect.AttributeOfType<BProperty>(property).Description;
                string propertyValue = HelpMeReflect.PropertyValueString(bClass, property);
                sb.Append($"{propertyName}={propertyValue}{DELIMITER}");
            }

            return sb.ToString();
        }
    }
}