using System.Collections.Generic;
using SchrijvenOpAfbeelding.Model;

namespace SchrijvenOpAfbeelding.Persistency
{
    public interface IBClassWriter
    {
        void Write(List<IBClass> bClass);
    }
}