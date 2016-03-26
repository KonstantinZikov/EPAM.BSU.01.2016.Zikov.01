using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task2;
using static System.Math;

namespace Task2Tests
{
    class MaxAbsComparer : IComparer<int[]>
    {
        public int Compare(int[] firstLine, int[] secondLine)
        {
            if (firstLine == null)
                throw new ArgumentNullException($"{nameof(firstLine)} is null.");
            if (secondLine == null)
                throw new ArgumentNullException($"{nameof(secondLine)} is null.");
            return MaxAbs(firstLine) - MaxAbs(secondLine);
        }

        public int MaxAbs(int[] line)
        {
            int result = 0;
            foreach (var element in line)
            {
                if (Abs(element) > result)
                {
                    result = Abs(element);
                }
            }
            return result;
        }
    }

    class MaxSumComparer : IComparer<int[]>
    {
        public int Compare(int[] firstLine, int[] secondLine)
        {
            if (firstLine == null)
                throw new ArgumentNullException($"{nameof(firstLine)} is null.");
            if (secondLine == null)
                throw new ArgumentNullException($"{nameof(secondLine)} is null.");
            return MaxSum(firstLine) - MaxSum(secondLine);
        }

        protected int MaxSum(int[] line)
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
    class MatrixLineSortsByIComparerTests
    {
        [Test]
        public void Sort_MaxAbsComparer_SortedResult()
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
        public void Sort_MaxSumComparer_SortedResult()
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
    }
}
