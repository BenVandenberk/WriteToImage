using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.ExtensionMethods;
using SchrijvenOpAfbeelding.Model.Core;
using static SchrijvenOpAfbeelding.HelpMe.HelpMe;

namespace SchrijvenOpAfbeelding.Persistency
{
    public class FileBClassWriter : FilePersistencyBClass, IBClassWriter
    {
        public FileBClassWriter(string path) : base(path) { }

        public void Write(List<IBClass> bClassList) {
            if (bClassList.Count > 0) {
                StringBuilder sb = new StringBuilder();
                foreach (IBClass b in bClassList) {
                    sb.Append(BClassToString(b)).NewLine();
                }

                HelpMeWrite.ToFile(BClassFullyQualifiedFileName(bClassList.ElementAt(0)), sb.ToString());
            }
        }
    }
}