using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrices
{
    public static class SquareMatrixAddExtention
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs)
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

        private static T Sum<T>(T lhs, T rhs) => (dynamic)lhs + rhs;
    }
}
