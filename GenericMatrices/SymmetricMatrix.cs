using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrices
{
    public sealed class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size)
        {
        }

        public override T this[int i, int j]
        {
            get => base[i, j];
            set
            {
                this.matrix[i, j] = value;
                this.matrix[j, i] = value;
                OnMatrixChanged(new MatrixChangeEventArg<T>(i, j, value));
            }
        }
    }
}
