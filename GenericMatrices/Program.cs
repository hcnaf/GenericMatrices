using System;

namespace GenericMatrices
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix1 = new SquareMatrix<bool>(4);
            var matrix2 = new SquareMatrix<bool>(4);

            var res = matrix1 + matrix2;
        }
    }
}
