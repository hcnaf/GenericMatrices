using NUnit.Framework;
using System.Collections.Generic;

namespace GenericMatricesTests
{
    class TestCasesSource
    {
        public static IEnumerable<TestCaseData> TestCasesForCtorBool
        {
            get
            {
                yield return new TestCaseData(
                    6,
                    new bool[,]
                    {
                        { false, false, false, false, false, false },
                        { false, false, false, false, false, false },
                        { false, false, false, false, false, false },
                        { false, false, false, false, false, false },
                        { false, false, false, false, false, false },
                        { false, false, false, false, false, false },
                    });
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForCtorInt
        {
            get
            {
                yield return new TestCaseData(
                    5,
                    new int[,]
                    {
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 },
                    });
            }
        }
    }
}
