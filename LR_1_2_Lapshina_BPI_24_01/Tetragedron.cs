using System;

namespace LR_1_2_Lapshina_BPI_24_01
{
    public class Tetrahedron : Figure
    {
        public double Side { get; set; }

        public Tetrahedron(double side) : base("Тетраэдр")
        {
            Side = side;
        }

        public override double GetVolume()
        {
            return Math.Pow(Side, 3) / (6 * Math.Sqrt(2));
        }

        public override double GetSurfaceArea()
        {
            return Math.Sqrt(3) * Side * Side;
        }
    }
}
