using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5._1
{
    public class SparseNumericMatrix : IEnumerable<long>
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        private Dictionary<(int, int), long> Elements { get; } = new Dictionary<(int, int), long>();

        public SparseNumericMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Number of rows and columns must be greater than zero.");
            }

            Rows = rows;
            Cols = columns;
        }

        public long this[int i, int j]
        {
            get
            {
                CheckIndices(i, j);
                return Elements.TryGetValue((i, j), out long value) ? value : 0;
            }
            set
            {
                CheckIndices(i, j);
                if (value == 0)
                {
                    Elements.Remove((i, j));
                }
                else
                {
                    Elements[(i, j)] = value;
                }
            }
        }

        private void CheckIndices(int i, int j)
        {
            if (i < 0 || i >= Rows || j < 0 || j >= Cols)
            {
                throw new IndexOutOfRangeException("Matrix indices are out of range.");
            }
        }

        public override string ToString()
        {
            var matrixString = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    matrixString.Append(this[i, j] + "\t");
                }
                matrixString.AppendLine();
            }
            return matrixString.ToString();
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            return Elements
                .OrderBy(e => e.Key.Item2)
                .ThenBy(e => e.Key.Item1)
                .Select(e => (e.Key.Item1, e.Key.Item2, e.Value));
        }

        public int GetCount(long x)
        {
            if (x == 0)
            {
                return Rows * Cols - Elements.Count;
            }
            return Elements.Values.Count(value => value == x);
        }
    }
}
