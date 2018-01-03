using System.Drawing;

namespace SchrijvenOpAfbeelding.Model
{
    public class Afbeelding
    {
        public string Path { get; set; }
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