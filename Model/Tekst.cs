using System.Drawing;
using SchrijvenOpAfbeelding.Crud;

namespace SchrijvenOpAfbeelding.Model
{
    [BClass(Description = "Tekst")]
    public class Tekst : IBClass
    {
        public Afbeelding Afbeelding { get; set; }
        public PointF Punt { get; set; }
        public string TeSchrijven { get; set; }

        public Tekst() {
            this.Afbeelding = new Afbeelding();
            this.Punt = new PointF();
            this.TeSchrijven = "";
        }

        public Tekst(Afbeelding afbeelding, PointF punt, string teSchrijven) {
            this.Afbeelding = afbeelding;
            this.Punt = punt;
            this.TeSchrijven = teSchrijven;
        }

        public override string ToString() {
            return $"Op punt [{this.Punt.X}, {this.Punt.Y}] van afbeelding {this.Afbeelding} wordt [{this.TeSchrijven}] geschreven";
        }
    }
}