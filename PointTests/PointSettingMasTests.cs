using HM2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PointTests
{
    [TestClass]
    public class PointSettingMassTests
    {
        
        private const double Epsilon = 0.000001;

        [TestMethod]
        public void PointSettingMassPositive()
        {
            Point point = new Point(1, 1, 1, 5);
            Assert.IsTrue(Math.Abs(point.Mass - 5) < Epsilon);
        }

        [TestMethod]
        public void PointSettingMassNegative()
        {
            Point point = new Point(1, 1, 1, -5);
            Assert.IsTrue(Math.Abs(point.Mass - 0) < Epsilon);
        }
    }
}
