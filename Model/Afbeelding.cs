using System.Drawing;
using SchrijvenOpAfbeelding.Crud;

namespace SchrijvenOpAfbeelding.Model
{
    [BClass(Description = "Afbeelding")]
    public class Afbeelding : IBClass
    {
        [BProperty(Description = "Lokaal pad")]
        public string Path { get; set; }
        [BProperty(Description = "Naam")]
        public string Naam { get; set; }
        public Bitmap Bitmap { get; set; }

        public Afbeelding() {
            this.Path = "N/A";
            this.Naam = "";
            this.Bitmap = new Bitmap(1, 1);
        }

        public Afbeelding(string path, string naam, Bitmap bitmap) {
            this.Path = path;
            this.Naam = naam;
            this.Bitmap = bitmap;
        }

        public string Afmetingen() {
            return $"[BREEDTE={this.Bitmap.Width} | HOOGTE={this.Bitmap.Height}]";
        }

        public override string ToString() {
            return $"[NAAM={this.Naam} | PAD={this.Path}]";
        }
    }
}