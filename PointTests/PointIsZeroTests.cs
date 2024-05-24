
using HM2;

namespace PointTests
{
    [TestClass]
    public class PointIsZeroTests
    {
        [TestMethod]
        public void PointIsZeroPositive()
        {
            Point point = new Point(0, 0, 0, 5);
            Assert.IsTrue(point.IsZero());
        }

        [TestMethod]
        public void PointIsZeroNegative()
        {
            Point point = new Point(0, 0, 1, 5);
           Assert.IsFalse(point.IsZero());
        }
    }
}
