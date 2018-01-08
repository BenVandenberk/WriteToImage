using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.Model.Core;
using SchrijvenOpAfbeelding.Persistency;
using SchrijvenOpAfbeelding.Reflection;

namespace SchrijvenOpAfbeelding.Program
{
    class Program
    {
        static void Main(string[] args) {
            Controller controller = new Controller();
            //controller.Run();

            Afbeelding afbeelding = new Afbeelding();
            afbeelding.Naam = "Test";
            afbeelding.Path = "TestPad";
            Afbeelding afbeelding2 = new Afbeelding();
            afbeelding2.Naam = "Test2";
            afbeelding2.Path = "TestPad2";
            List<IBClass> afbeeldings = new List<IBClass>() {afbeelding2, afbeelding};

            FileBClassWriter writer = new FileBClassWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            DataContext dataContext = new DataContext(writer);
            dataContext.Add(afbeelding);
            Console.ReadLine();
            dataContext.Add(afbeelding2);
            Console.ReadLine();
            dataContext.Delete(afbeelding);
            Console.ReadLine();
            List<PropertyInfo> properties = HelpMe.PropertiesWithBPropertyAttribute(typeof(Afbeelding));
            PropertyInfo naamPropertyInfo =
                properties.Find(prop => prop.GetCustomAttribute<BProperty>().Description.Equals("Naam"));
            dataContext.Update(afbeelding2, naamPropertyInfo, "Veranderde naam");
            Console.ReadLine();

            Console.ReadLine();

        }
    }
}
