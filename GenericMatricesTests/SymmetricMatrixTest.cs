using GenericMatrices;
using NUnit.Framework;

namespace GenericMatricesTests
{
    public class SymmetricMatrixTest
    {
        public void SymmetricMatrixChange()
        {
            var matrix = new SquareMatrix<int>(5);
            matrix.MatrixChanged += MatrixChanged;

            bool invoked = false;

            matrix[3, 4] = 56;

            void MatrixChanged(object sender, MatrixChangeEventArg<int> info)
            {
                Assert.AreEqual(3, info.I);
                Assert.AreEqual(4, info.J);
                Assert.AreEqual(56, info.Value);
                Assert.AreEqual(matrix[3, 4], matrix[4, 3]);
                invoked = true;
            }

            Assert.IsTrue(invoked);
        }
    }
}
