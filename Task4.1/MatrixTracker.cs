
namespace Task4._1
{
    public class MatrixTracker<T>
    {
        private readonly GenericDiagonalMatrix<T> matrix;
        private MatrixElementChangedEventArgs<T> lastChange;

        public MatrixTracker(GenericDiagonalMatrix<T> matrix)
        {
            this.matrix = matrix ?? throw new ArgumentNullException(nameof(matrix));
            this.matrix.ElementChanged += Matrix_ElementChanged;
        }

        public void Undo()
        {
            if (lastChange != null)
            {
                matrix[lastChange.Row, lastChange.Column] = lastChange.OldValue;
                lastChange = null;
            }
        }

        private void Matrix_ElementChanged(object sender, MatrixElementChangedEventArgs<T> e)
        {
            lastChange = e;
        }
    }
}
