namespace Task2._2
{
    public class DiagonalMatrix
    {
        private readonly int[] elements;
        private readonly int size;

        public int Size => size;

        public DiagonalMatrix(int[] diagonalElements)
        {
            if (diagonalElements == null)
            {
                size = 0;
                elements = new int[0];
            }
            else
            {
                size = diagonalElements.Length;
                elements = new int[size];
                Array.Copy(diagonalElements, elements, size);
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= size || j >= size || i != j)
                    return 0;
                return elements[i];
            }
        }

        public int Track()
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += elements[i];
            }
            return sum;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DiagonalMatrix))
            {
                return false;
            }

            DiagonalMatrix comparingMatrix = (DiagonalMatrix)obj;

            if (size != comparingMatrix.size)
            {
                return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (elements[i] != comparingMatrix.elements[i])
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"Diagonal Matrix of size {size}";
        }
    }

    public static class DiagonalMatrixExtensions
    {
        internal static DiagonalMatrix Add(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
        {
            int maxSize = Math.Max(matrix1.Size, matrix2.Size);
            int[] resultElements = new int[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                int value1 = i < matrix1.Size ? matrix1[i, i] : 0;
                int value2 = i < matrix2.Size ? matrix2[i, i] : 0;
                resultElements[i] = value1 + value2;
            }

            return new DiagonalMatrix(resultElements);
        }
    }
}
