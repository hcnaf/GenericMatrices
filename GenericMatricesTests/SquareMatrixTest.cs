using NUnit.Framework;
using GenericMatrices;

namespace GenericMatricesTests
{
    public class SquareMatrixTest
    {
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCtorBool))]
        public void CtorBoolTest_GeneratesMatrixWithDefaultValue(int size, bool[,] expectedResult)
        {
            var matrix = new SquareMatrix<bool>(size);
            Assert.AreEqual(expectedResult, matrix.GetMatrix());
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCtorInt))]
        public void CtorIntTest_GeneratesMatrixWithDefaultValue(int size, int[,] expectedResult)
        {
            var matrix = new SquareMatrix<int>(size);
            Assert.AreEqual(expectedResult, matrix.GetMatrix());
        }

        [Test]
        public void ChangeMatrixElement_InvokesEvent()
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
                invoked = true;
            }

            Assert.IsTrue(invoked);
        }
    }
}