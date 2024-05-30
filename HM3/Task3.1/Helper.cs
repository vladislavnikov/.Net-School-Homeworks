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
            IQueue<T> tempQueue = new Queue<T>();

            while (!queue.isEmpty())
            {
                tempQueue.Enqueue(queue.Dequeue());
            }

            while (!tempQueue.isEmpty())
            {
                T item = tempQueue.Dequeue();
                queue.Enqueue(item);
                if (!queue.isEmpty()) 
                {
                    newQueue.Enqueue(item);
                }
            }

            return newQueue;
        }
    }
}
