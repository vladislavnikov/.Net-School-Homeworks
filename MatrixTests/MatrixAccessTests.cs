
using Task2._2;

namespace MatrixTests
{
    [TestClass]
    public class MatrixAccessTests
    {
        [TestMethod]
        public void MatrixSettingSizePositive()
        {
            int[] diagonalElements = new int[] { 1, 2, 3 };
            DiagonalMatrix matrix = new DiagonalMatrix(diagonalElements);

            int element = matrix[1, 1];

            Assert.AreEqual(2, element);
        }

        [TestMethod]
        public void MatrixSettingSizeNegative()
        {
            int[] diagonalElements = new int[] { };
            DiagonalMatrix matrix = new DiagonalMatrix(diagonalElements);

            int element = matrix[3, 3];

            Assert.IsTrue(element == 0);
        }
    }
}
