
using Task3._1;

namespace QueueTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void EnqueuePositive()
        {
            Task3._1.Queue<int> queue = new Task3._1.Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count());
        }

        [TestMethod]
        public void DequeuePositive()
        {
            Task3._1.Queue<int> queue = new Task3._1.Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Count());
        }

        [TestMethod]
        public void CheckingIsEmptyPositive()
        {
            Task3._1.Queue<int> queue = new Task3._1.Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.IsFalse(queue.isEmpty());
        }

        [TestMethod]
        public void CheckingIsEmptyNegative()
        {
            Task3._1.Queue<int> queue = new Task3._1.Queue<int>();

            Assert.IsTrue(queue.isEmpty());
        }

    }
}
