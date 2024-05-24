

namespace Task3._1
{
    public class Queue<T> : IQueue<T>
    {
       private LinkedList<T> queue = new LinkedList<T>();

        private int count = 0;

        public T Dequeue()
        {
            count--;
            var firstElement = queue.First();
            queue.RemoveFirst();
            return firstElement;
        }

        public bool Enqueue(T item)
        {
            count++;
            queue.AddLast(item);
            return count < queue.Count;
        }

        public bool isEmpty()
        {
            return queue.Count == 0;
        }

        public int Count() => queue.Count;
    }
}
