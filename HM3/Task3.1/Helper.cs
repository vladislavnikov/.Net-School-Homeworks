
namespace Task3._1
{
    public static class Helper
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue)
        {
            if (queue.isEmpty())
            {
                throw new InvalidOperationException("Empty queue!");
            }

            IQueue<T> newQueue = new Queue<T>();

            queue.Dequeue();

            while (!queue.isEmpty())
            {
                newQueue.Enqueue(queue.Dequeue());
            }

            return newQueue;
        }
    }
}
