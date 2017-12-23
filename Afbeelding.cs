using System;

namespace SchrijvenOpAfbeelding
{
    public class Afbeelding
    {
        public string Path { get; set; }
        public string Naam { get; set; }

        public Afbeelding() {
            this.Path = "N/A";
            this.Naam = "";
        }

        public Afbeelding(string path, string naam) {
            this.Path = path;
            this.Naam = naam;
        }

        public override string ToString() {
            return $"[{this.Naam}] {this.Path}";
        }
    }
}