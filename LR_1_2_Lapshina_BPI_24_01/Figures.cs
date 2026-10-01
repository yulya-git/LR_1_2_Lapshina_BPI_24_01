namespace LR_1_2_Lapshina_BPI_24_01
{
    public class Figure : Shape
    {
        public string Name { get; protected set; }

        public Figure(string name)
        {
            Name = name;
        }

        public virtual double GetVolume()
        {
            return 0.0;
        }

        public virtual double GetSurfaceArea()
        {
            return 0.0;
        }
    }
}
