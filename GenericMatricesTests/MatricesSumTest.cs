using GenericMatrices;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;

namespace GenericMatricesTests
{
    class MatricesSumTest
    {
        [Test]
        public static void SumMatrices_Int()
        {
            var matrix1 = new SquareMatrix<int>(6);
            var matrix2 = new SymmetricMatrix<int>(6);

            matrix1[1, 2] = 5;
            matrix2[4, 2] = 1;

            var res = matrix1.Add(matrix2);

            var expectedResult = new SquareMatrix<int>(6);
            expectedResult[1, 2] = 5;
            expectedResult[4, 2] = 1;
            expectedResult[2, 4] = 1;

            Assert.IsTrue(expectedResult.Equals(res));            
        }

        [Test]
        public static void SumMatrices_InvlidTypes()
        {
            var matrix1 = new SquareMatrix<bool>(4);
            var matrix2 = new SquareMatrix<bool>(4);

            Assert.Throws<RuntimeBinderException>(() => matrix1.Add(matrix2));
        }
    }
}
