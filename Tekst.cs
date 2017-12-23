﻿using System.Drawing;

namespace SchrijvenOpAfbeelding
{
    public class Tekst
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
    }
}