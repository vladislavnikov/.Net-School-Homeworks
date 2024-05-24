namespace HM2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1,2,3,5);

            Point point2 = new Point(-4,5,6,-8);

            Point point3 = new Point(0,0,0,-10);

            double distance = point1.DistanceToOtherPoint(point2);
            Console.WriteLine((float)Math.Round(distance, 2));

            Console.WriteLine(point1.IsZero());
            Console.WriteLine(point3.IsZero());
        }
    }
}
