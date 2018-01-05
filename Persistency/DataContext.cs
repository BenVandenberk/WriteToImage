using System;
using System.Collections.Generic;
using SchrijvenOpAfbeelding.Model;
using Type = System.Type;

namespace SchrijvenOpAfbeelding.Persistency
{
    public class DataContext
    {
        public List<IBClass> Afbeeldingen { get; }
        public List<IBClass> Tekstjes { get; }
        public List<IBClass> Schrijvers { get; }

        private Dictionary<Type, List<IBClass>> data;

        private IBClassWriter bClassWriter;

        public DataContext(IBClassWriter bClassWriter) {
            this.bClassWriter = bClassWriter;
            this.data = new Dictionary<Type, List<IBClass>>();

            this.Afbeeldingen = new List<IBClass>();
            this.data[typeof(Afbeelding)] = this.Afbeeldingen;

            this.Tekstjes = new List<IBClass>();
            this.data[typeof(Tekst)] = this.Tekstjes;

            this.Schrijvers = new List<IBClass>();
            this.data[typeof(Schrijver)] = this.Schrijvers;
        }

        public void Update<T>(T item) where T : IBClass {

        }

        public void Add<T>(T item) where T : IBClass {

        }

        public void Delete<T>(T item) where T : IBClass {

        }

        public void FireChanged(Type type) {

        }
    }
}