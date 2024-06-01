
using Task2._2;

namespace MatrixTests
{
    [TestClass]
    public class MatrixEqualityTests
    {
        [TestMethod]
        public void MatrixEqualityPositive()
        {
            int[] diagonalElements = new int[] { 1, 2, 3 };
            DiagonalMatrix matrix1 = new DiagonalMatrix(diagonalElements);

            int[] diagonalElements2 = new int[] { 1, 2, 3 };
            DiagonalMatrix matrix2 = new DiagonalMatrix(diagonalElements2);

            bool isEqual = matrix1.Equals(matrix2);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void MatrixEqualityNegative()
        {
            int[] diagonalElements = new int[] { 1, 2, 3 };
            DiagonalMatrix matrix1 = new DiagonalMatrix(diagonalElements);

            int[] diagonalElements2 = new int[] { 1, 2, 3, 4 };
            DiagonalMatrix matrix2 = new DiagonalMatrix(diagonalElements2);

            bool isEqual = matrix1.Equals(matrix2);

            Assert.IsFalse(isEqual);
        }
    }
}
