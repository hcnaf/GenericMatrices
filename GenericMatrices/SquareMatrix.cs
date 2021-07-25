using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrices
{
    public class SquareMatrix<T> : IEquatable<SquareMatrix<T>>
    {
        public T[,] matrix;

        protected readonly int Size;

        public SquareMatrix(int size)
        {
            this.Size = size > 0 ? size : throw new ArgumentOutOfRangeException(nameof(size));
            this.matrix = new T[size, size];

            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    this.matrix[i, j] = default;
        }

        public T[,] GetMatrix() => this.matrix;

        public event EventHandler<MatrixChangeEventArg<T>> MatrixChanged = delegate { };

        public virtual T this[int i, int j]
        {
            get => matrix[i, j];
            set
            {
                matrix[i, j] = value;
                this.OnMatrixChanged(new MatrixChangeEventArg<T>(i, j, value));
            }
        }

        public bool Equals(SquareMatrix<T> other)
        {
            if (other.Size != this.Size || other is null)
            {
                return false;
            }

            for (int i = 0; i < this.Size; ++i)
            {
                for (int j = 0; j < this.Size; ++j)
                {
                    switch (this[i,j], other[i,j])
                    {
                        case (null, null):
                            continue;
                        case (null, _):
                            return false;
                        case (_, null):
                            return false;
                    }

                    if (!this.matrix[i, j].Equals(other[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected void OnMatrixChanged(MatrixChangeEventArg<T> change)
        {
            this.MatrixChanged(this, change);
        }

        public static SquareMatrix<T> operator +(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            if (lhs is null)
                throw new ArgumentNullException(nameof(lhs));
            if (rhs is null)
                throw new ArgumentNullException(nameof(rhs));

            if (lhs.Size != rhs.Size)
            {
                throw new InvalidOperationException("Sizes of matrices are different.");
            }

            var matrix = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                for (int j = 0; j < lhs.Size; ++j)
                {
                    matrix[i, j] = Sum(lhs[i, j], rhs[i, j]);
                }
            }

            return matrix;
        }

        private static T Sum(T lhs, T rhs) => (dynamic)lhs + rhs;
    }
}
