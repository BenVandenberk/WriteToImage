using System.Collections.Generic;
using SchrijvenOpAfbeelding.Model;
using SchrijvenOpAfbeelding.Model.Core;

namespace SchrijvenOpAfbeelding.Persistency
{
    public interface IBClassWriter
    {
        void Write(List<IBClass> bClass);
    }
}