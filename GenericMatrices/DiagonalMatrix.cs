using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrices
{
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size)
        {
        }

        public override T this[int i, int j]
        {
            get => base[i, j];
            set
            {
                if (i != j)
                {

                    throw new InvalidOperationException("You can change only diagonal element.");
                }

                this.matrix[i, j] = value;
                OnMatrixChanged(new MatrixChangeEventArg<T>(i, j, value));
            }
        }
    }
}
