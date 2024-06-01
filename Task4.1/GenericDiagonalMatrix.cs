using System;

namespace Task4._1
{
    public class GenericDiagonalMatrix<T>
    {
        private readonly T[] elements;

        public int Size { get; }

        public event EventHandler<MatrixElementChangedEventArgs<T>> ElementChanged;

        public GenericDiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size cannot be negative.");
            }

            elements = new T[size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                if (i != j)
                {
                    return default(T); 
                }

                return elements[i];
            }
            set
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                if (i == j && !elements[i].Equals(value)) 
                {
                    T oldValue = elements[i];
                    elements[i] = value;
                    OnElementChanged(new MatrixElementChangedEventArgs<T>(i, j, oldValue, value));
                }
            }
        }

        protected virtual void OnElementChanged(MatrixElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }

    }

    public class MatrixElementChangedEventArgs<T> : EventArgs
    {
        public int Row { get; }
        public int Column { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public MatrixElementChangedEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
