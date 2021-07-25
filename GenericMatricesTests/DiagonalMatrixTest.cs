using System;
using GenericMatrices;
using NUnit.Framework;

namespace GenericMatricesTests
{
    public class DiagonalMatrixTest
    {
        [Test]
        public void DiagonalMatrixChange_InvokesEvent()
        {
            var matrix = new DiagonalMatrix<int>(5);

            matrix.MatrixChanged += MatrixChanged;
            bool invoked = false;
            matrix[4, 4] = 2;

            void MatrixChanged(object sender, MatrixChangeEventArg<int> info)
            {
                Assert.AreEqual(4, info.I);
                Assert.AreEqual(4, info.J);
                Assert.AreEqual(2, info.Value);
                invoked = true;
            }

            Assert.IsTrue(invoked);
        }

        [Test]
        public void DiagonalMatrixChange_NotDIagonalElement()
        {
            var matrix = new DiagonalMatrix<int>(5);

            Assert.Throws<InvalidOperationException>(() => matrix[4, 1] = 2);
        }
    }
}
