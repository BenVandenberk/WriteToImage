using System.Collections.Generic;

namespace SchrijvenOpAfbeelding.Persistency
{
    public interface IBClassLoader
    {
        List<T> Load<T>();
    }
}