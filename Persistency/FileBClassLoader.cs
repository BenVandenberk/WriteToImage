using System;
using System.Collections.Generic;
using static SchrijvenOpAfbeelding.HelpMe.HelpMe;

namespace SchrijvenOpAfbeelding.Persistency
{
    public class FileBClassLoader : FilePersistencyBClass, IBClassLoader
    {
        public FileBClassLoader(string path) : base(path) { }

        public List<T> Load<T>() {
            throw new NotImplementedException();
        }
    }
}