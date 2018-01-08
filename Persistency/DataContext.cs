using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using SchrijvenOpAfbeelding.Model;
using SchrijvenOpAfbeelding.Model.Core;
using Type = System.Type;

namespace SchrijvenOpAfbeelding.Persistency
{
    public class DataContext
    {
        public List<Tekst> Tekstjes => this.data[typeof(Tekst)].Cast<Tekst>().ToList();
        public List<Schrijver> Schrijvers => this.data[typeof(Schrijver)].Cast<Schrijver>().ToList();
        public List<Afbeelding> Afbeeldingen => this.data[typeof(Afbeelding)].Cast<Afbeelding>().ToList();

        private Dictionary<Type, List<IBClass>> data;

        private IBClassWriter bClassWriter;

        public DataContext(IBClassWriter bClassWriter) {
            this.bClassWriter = bClassWriter;
            this.data = new Dictionary<Type, List<IBClass>>();
            
            this.data[typeof(Afbeelding)] = new List<IBClass>();
            this.data[typeof(Tekst)] = new List<IBClass>();
            this.data[typeof(Schrijver)] = new List<IBClass>();
        }

        public void Update<T>(T item, PropertyInfo property, object newValue) where T : IBClass {
            property.SetValue(item, newValue);
            FireChanged(item.GetType());
        }

        public void Add<T>(T item) where T : IBClass {
            List<IBClass> list;
            this.data.TryGetValue(item.GetType(), out list);

            if (list != null) {
                list.Add(item);
            } else {
                this.data[item.GetType()] = new List<IBClass>() {item};
            }

            FireChanged(item.GetType());
        }

        public void Delete<T>(T item) where T : IBClass {
            List<IBClass> list;
            this.data.TryGetValue(item.GetType(), out list);

            list?.Remove(item);
            FireChanged(item.GetType());
        }

        public void FireChanged(Type type) {
            this.bClassWriter.Write(this.data[type]);
        }
    }
}