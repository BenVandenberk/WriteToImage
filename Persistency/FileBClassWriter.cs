using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.ExtensionMethods;
using SchrijvenOpAfbeelding.Model.Core;
using static SchrijvenOpAfbeelding.HelpMe.HelpMe;

namespace SchrijvenOpAfbeelding.Persistency
{
    public class FileBClassWriter : IBClassWriter
    {
        private const string DELIMITER = "\t";

        public string Pad { get; set; }

        public FileBClassWriter(string pad) {
            this.Pad = pad;
        }

        public void Write(List<IBClass> bClassList) {
            if (bClassList.Count > 0) {
                StringBuilder sb = new StringBuilder();
                foreach (IBClass b in bClassList) {
                    sb.Append(BClassToString(b)).NewLine();
                }

                WriteToFile(BClassFileName(bClassList.ElementAt(0)), sb.ToString());
            }
        }

        private string BClassFileName(IBClass bClass) {
            StringBuilder sb = new StringBuilder();
            sb.Append(HelpMeReflect.AttributeStringData(bClass.GetType(), typeof(BClass), "Description"));
            sb.Append(".txt");
            return sb.ToString();
        }

        private string BClassToString(IBClass bClass) {
            List<PropertyInfo> properties = HelpMeReflect.PropertiesWithBPropertyAttribute(bClass.GetType());
            StringBuilder sb = new StringBuilder();
            
            foreach (PropertyInfo property in properties) {
                string propertyName = HelpMeReflect.AttributeOfType<BProperty>(property).Description;
                string propertyValue = HelpMeReflect.PropertyValueString(bClass, property);
                sb.Append($"{propertyName}={propertyValue}{DELIMITER}");
            }

            return sb.ToString();
        }

        private void WriteToFile(string fileName, string text) {
            using (StreamWriter outputFile = new StreamWriter($@"{this.Pad}\\{fileName}")) {
                outputFile.Write(text);
            }
        }
    }
}