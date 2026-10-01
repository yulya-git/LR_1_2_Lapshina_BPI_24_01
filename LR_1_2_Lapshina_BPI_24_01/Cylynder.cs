using System;

namespace LR_1_2_Lapshina_BPI_24_01
{
    public class Cylinder : Figure
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public Cylinder(double radius, double height) : base("Цилиндр")
        {
            Radius = radius;
            Height = height;
        }

        public override double GetVolume()
        {
            return Math.PI * Radius * Radius * Height;
        }

        public override double GetSurfaceArea()
        {
            return 2 * Math.PI * Radius * (Radius + Height);
        }
    }
}
