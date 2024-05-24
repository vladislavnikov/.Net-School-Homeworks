
using Task2._2;

namespace MatrixTests
{
    [TestClass]
    public class MatrixSettingSizeTests
    {
        [TestMethod]
        public void MatrixSettingSizePositive()
        {
            int[] diagonalElements = new int[] { 1, 2, 3 };
            DiagonalMatrix matrix = new DiagonalMatrix(diagonalElements);

            int size = matrix.Size;

            Assert.AreEqual(3, size);
        }

        [TestMethod]
        public void MatrixSettingSizeNegative()
        {
            int[] diagonalElements = new int[] { };
            DiagonalMatrix matrix = new DiagonalMatrix(diagonalElements);

            Assert.AreEqual(matrix.Size, 0);
        }
    }
}
