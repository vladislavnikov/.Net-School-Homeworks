
namespace Task3._1
{
    public interface IQueue<T> 
    {
        bool Enqueue(T item);
        T Dequeue();
        bool isEmpty();

        int Count();
    }
}
