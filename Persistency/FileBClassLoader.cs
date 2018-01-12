using System;
using System.Collections.Generic;

namespace SchrijvenOpAfbeelding.Persistency
{
    public class FileBClassLoader : IBClassLoader
    {
        public string Pad { get; set; }

        public FileBClassLoader(string pad) {
            this.Pad = pad;
        }

        public List<T> Load<T>() {
            throw new NotImplementedException();
        }
    }
}