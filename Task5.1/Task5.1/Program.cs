namespace Task5._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sparseMatrix = new SparseNumericMatrix(3, 3);
            sparseMatrix[0, 0] = 1;
            sparseMatrix[1, 1] = 2;
            sparseMatrix[2, 2] = 3;

            Console.WriteLine(sparseMatrix.ToString());

            foreach (var (i, j, value) in sparseMatrix.GetNonzeroElements())
            {
                Console.WriteLine($"({i}, {j}) = {value}");
            }

            Console.WriteLine(sparseMatrix.GetCount(0));

            Console.WriteLine(sparseMatrix.GetCount(1));

            foreach (var value in sparseMatrix)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}
