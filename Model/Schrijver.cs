using System;
using System.Drawing;
using System.Text;

namespace SchrijvenOpAfbeelding.Model
{
    public class Schrijver
    {
        public Font Font { get; set; }
        public Brush Brush { get; set; }
        public string OutputPath { get; set; }

        public Schrijver(Font font, Brush brush, string outputPath) {
            this.Font = font;
            this.Brush = brush;
            this.OutputPath = outputPath;
        }

        public void Schrijf(Tekst tekst, string volgNummer = "") {
            Bitmap afbeelding = (Bitmap) Image.FromFile(tekst.Afbeelding.Path);
            Bitmap afbeeldingMetTekst = new Bitmap(afbeelding.Height, afbeelding.Width);

            using (Graphics graphics = Graphics.FromImage(afbeeldingMetTekst)) {
                graphics.DrawImage(afbeelding, 0, 0);

                using (this.Font) {
                    graphics.DrawString(tekst.TeSchrijven, this.Font, this.Brush, tekst.Punt);
                }
            }

            afbeeldingMetTekst.Save(Filename(tekst.Afbeelding.Naam, volgNummer));
        }

        private string Filename(string afbeeldingNaam, string volgNummer) {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.OutputPath}\\{afbeeldingNaam}-");

            if (!volgNummer.Equals("")) {
                sb.Append($"{volgNummer}-");
            }

            sb.Append(DateTime.Now);

            return sb.ToString();
        }
    }
}