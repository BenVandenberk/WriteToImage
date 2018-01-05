using System;
using System.Drawing;
using SchrijvenOpAfbeelding.Crud;

namespace SchrijvenOpAfbeelding.Model.Core
{
    [BClass(Description = "Afbeelding")]
    public class Afbeelding : IBClass
    {
        [BProperty(Description = "Id")]
        public Guid Guid { get; }

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

        public Afbeelding(string path, string naam, Bitmap bitmap, Guid guid) {
            this.Path = path;
            this.Naam = naam;
            this.Bitmap = bitmap;
            this.Guid = guid;
        }

        public string Afmetingen() {
            return $"[BREEDTE={this.Bitmap.Width} | HOOGTE={this.Bitmap.Height}]";
        }

        public override string ToString() {
            return $"[NAAM={this.Naam} | PAD={this.Path}]";
        }
    }
}