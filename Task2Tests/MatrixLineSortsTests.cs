using NUnit.Framework;
using Task2;
using static System.Math;
namespace Task2Tests
{
    class MaxAbsComparer : MatrixLineComparer
    {
        public override int CompareFunction(int[] line)
        {
            int result = 0;
            foreach(var element in line)
            {
                if (Abs(element) > result)
                {
                    result = Abs(element);
                }
            }
            return result;
        }
    }

    class MaxSumComparer : MatrixLineComparer
    {
        public override int CompareFunction(int[] line)
        {
            int result = 0;
            foreach (var element in line)
            {
                result += element;
            }
            return result;
        }
    }

    [TestFixture]
    class MatrixLineSortsTests
    {
        [Test]
        public void Sort_MaxAbsComparerInAscedingOrder_SortedResult()
        {
            //arrange
            int[][] matrix = new int[][]
            {
                new [] {5, 315, -400, 0},
                new [] {24, 55, 350, -45},
                new [] {90, 21, 22, 22},
                new [] {415, 89, -1000, 999},
            };
            var comparer = new MaxAbsComparer();

            //act
            matrix.Sort(comparer);

            //assert
            Assert.AreEqual(90,matrix[0][0]);
            Assert.AreEqual(24, matrix[1][0]);
            Assert.AreEqual(5, matrix[2][0]);
            Assert.AreEqual(415, matrix[3][0]);
        }

        [Test]
        public void Sort_MaxAbsComparerInDescedingOrder_SortedResult()
        {
            //arrange
            int[][] matrix = new int[][]
            {
                new [] {5, 315, -400, 0},
                new [] {24, 55, 350, -45},
                new [] {90, 21, 22, 22},
                new [] {415, 89, -1000, 999},
            };
            var comparer = new MaxAbsComparer();

            //act
            matrix.Sort(comparer,false);

            //assert
            Assert.AreEqual(415, matrix[0][0]);
            Assert.AreEqual(5, matrix[1][0]);
            Assert.AreEqual(24, matrix[2][0]);
            Assert.AreEqual(90, matrix[3][0]);
        }

        [Test]
        public void Sort_MaxSumComparerInAscedingOrder_SortedResult()
        {
            //arrange
            int[][] matrix = new int[][]
            {
                new [] {5, 315, -400, 0},//-80
                new [] {24, 55, 350, -45},//384
                new [] {90, 21, 22, 22},//155
                new [] {415, 89, -1000, 999},//504
            };
            var comparer = new MaxSumComparer();

            //act
            matrix.Sort(comparer);

            //assert
            Assert.AreEqual(5, matrix[0][0]);
            Assert.AreEqual(90, matrix[1][0]);
            Assert.AreEqual(24, matrix[2][0]);
            Assert.AreEqual(415, matrix[3][0]);
        }

        [Test]
        public void Sort_MaxSumComparerInDecedingOrder_SortedResult()
        {
            //arrange
            int[][] matrix = new int[][]
            {
                new [] {5, 315, -400, 0},//-80
                new [] {24, 55, 350, -45},//384
                new [] {90, 21, 22, 22},//155
                new [] {415, 89, -1000, 999},//504
            };
            var comparer = new MaxSumComparer();

            //act
            matrix.Sort(comparer,false);

            //assert
            Assert.AreEqual(415, matrix[0][0]);
            Assert.AreEqual(24, matrix[1][0]);
            Assert.AreEqual(90, matrix[2][0]);
            Assert.AreEqual(5, matrix[3][0]);
        }

    }
}
