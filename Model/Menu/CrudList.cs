using System.Collections.Generic;
using System.Reflection;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    public class CrudList<T>
    {
        public List<T> List { get; }

        public CrudList(List<T> list) {
            this.List = list;
        }

        public void Delete(T item) {
            this.List.Remove(item);
        }

        public void Add(T item) {
            this.List.Add(item);
        }

        public void Clear() {
            this.List.Clear();
        }
    }
}