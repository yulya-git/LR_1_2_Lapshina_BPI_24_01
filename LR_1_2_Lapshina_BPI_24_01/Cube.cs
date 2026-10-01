using System;

namespace LR_1_2_Lapshina_BPI_24_01
{
    public class Cube : Figure
    {
        public double Side { get; set; }

        public Cube(double side) : base("Куб")
        {
            Side = side;
        }

        public override double GetVolume()
        {
            return Math.Pow(Side, 3);
        }

        public override double GetSurfaceArea()
        {
            return 6 * Side * Side;
        }
    }
}
