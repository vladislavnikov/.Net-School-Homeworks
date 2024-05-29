
using Task5._1;

namespace SparseNumericMatrixTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatrixInitialization()
        {
            var matrix = new SparseNumericMatrix(5, 5);
            Assert.AreEqual(5, matrix.Rows);
            Assert.AreEqual(5, matrix.Cols);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidMatrixInitialization()
        {
            var matrix = new SparseNumericMatrix(0, 5);
        }

        [TestMethod]
        public void TestElementAssignmentAndRetrieval()
        {
            var matrix = new SparseNumericMatrix(3, 3);
            matrix[1, 1] = 10;
            Assert.AreEqual(10, matrix[1, 1]);
            Assert.AreEqual(0, matrix[0, 0]);  
        }

        [TestMethod]
        public void TestElementRemoval()
        {
            var matrix = new SparseNumericMatrix(3, 3);
            matrix[1, 1] = 10;
            matrix[1, 1] = 0;  
            Assert.AreEqual(0, matrix[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestInvalidIndexAccess()
        {
            var matrix = new SparseNumericMatrix(3, 3);
            var value = matrix[3, 3]; 
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            var matrix = new SparseNumericMatrix(2, 2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;
            var expected = "1\t0\t\n0\t2\t\n";
            Assert.AreEqual(expected, matrix.ToString());
        }

        [TestMethod]
        public void TestGetNonzeroElements()
        {
            var matrix = new SparseNumericMatrix(3, 3);
            matrix[0, 0] = 1;
            matrix[2, 1] = 5;
            matrix[1, 2] = 3;
            var nonZeroElements = matrix.GetNonzeroElements().ToList();
            var expected = new (int, int, long)[] { (0, 0, 1), (2, 1, 5), (1, 2, 3) };
            CollectionAssert.AreEqual(expected, nonZeroElements);
        }

        [TestMethod]
        public void TestGetCount()
        {
            var matrix = new SparseNumericMatrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[1, 0] = 2;
            matrix[1, 1] = 2;
            Assert.AreEqual(2, matrix.GetCount(1));
            Assert.AreEqual(2, matrix.GetCount(2));
            Assert.AreEqual(0, matrix.GetCount(3));
            Assert.AreEqual(0, matrix.GetCount(0));  
        }

        [TestMethod]
        public void TestZeroCount()
        {
            var matrix = new SparseNumericMatrix(3, 3);
            matrix[0, 0] = 1;
            matrix[1, 1] = 1;
            Assert.AreEqual(7, matrix.GetCount(0));  
        }

        [TestMethod]
        public void TestEnumerator()
        {
            var matrix = new SparseNumericMatrix(2, 2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;
            var elements = matrix.ToArray();
            var expected = new long[] { 1, 0, 0, 2 };
            CollectionAssert.AreEqual(expected, elements);
        }
    }
}
