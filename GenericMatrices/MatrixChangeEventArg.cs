using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrices
{
    public sealed class MatrixChangeEventArg<T> : EventArgs
    {
        public int I { get; private set; }
        public int J { get; private set; }
        public T Value { get; private set; }
        public MatrixChangeEventArg(int i, int j, T value)
        {
            this.I = i;
            this.J = j;
            this.Value = value;
        }
    }
}
