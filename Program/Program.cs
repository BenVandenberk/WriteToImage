using System;
using System.Collections.Generic;
using SchrijvenOpAfbeelding.Model.Core;
using SchrijvenOpAfbeelding.Persistency;

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
            writer.Write(afbeeldings);

            Console.ReadLine();

        }
    }
}
