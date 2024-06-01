namespace HM2
{
    public class Point
    {
        private int[] coordinates = new int[3];
        private double mass;

        public Point(int x, int y, int z, int mass)
        {
            this.X = x;
            this.Y = y;
            this.Z = z; 
            this.Mass = mass;
        }
        public int X
        {
            get
            {
                return coordinates[0];
            }
            set
            {
                coordinates[0] = value;
            }
        }

        public int Y
        {
            get
            {
                return coordinates[1];
            }
            set
            {
                coordinates[1] = value;
            }
        }

        public int Z
        {
            get
            {
                return coordinates[2];
            }
            set
            {
                coordinates[2] = value;
            }
        }

        public double Mass
        {
            get
            {
                return mass;
            }
            set
            {
                if (value < 0)
                {
                    mass = 0;
                }
                else
                {
                    mass = value;
                }
            }
        }

        public bool IsZero()
        {
            return (X == 0 && Y == 0 && Z == 0);
        }

        public double DistanceToOtherPoint(Point other)
        {
            int x = X - other.X;
            int y = Y - other.Y;
            int z = Z - other.Z;
            return Math.Sqrt(x * x + y * y + z * z);
        }
    }
}
