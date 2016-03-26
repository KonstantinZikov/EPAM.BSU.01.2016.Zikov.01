using System.Collections.Generic;
using System;

namespace Task2
{
    public static class MatrixLineSortsByIComparer
    {
        private class ComparerAdapter : IComparer<int[]>
        {
            private Comparison<int[]> comparison;
            public ComparerAdapter(Comparison<int[]> comparison)
            {
                if (comparison == null)
                    throw new ArgumentNullException($"{nameof(comparison)} is null.");
                this.comparison = comparison;
            }
            public int Compare(int[] x, int[] y)
                => comparison(x, y);
        }

        public static void Sort(this int[][] matrix, Comparison<int[]> comparison)
            => Sort(matrix, new ComparerAdapter(comparison));

        private static void Sort(int[][] matrix, IComparer<int[]> comparer)
        {
            for (int i = 0; i < matrix?.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                    if ((comparer.Compare(matrix[i], matrix[j]) < 0))
                        Swap(ref matrix[i], ref matrix[j]);
        }

        private static void Swap(ref int[] firstLine, ref int[] secondLine)
        {
            var tempLine = firstLine;
            firstLine = secondLine;
            secondLine = tempLine;
        }
    }

    public static class MatrixLineSortsByDelegate 
    {
        public static void Sort(this int[][] matrix, IComparer<int[]> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException($"{nameof(comparer)} is null.");
            Sort(matrix, comparer.Compare);
        }

        private static void Sort(int[][] matrix, Comparison<int[]> comparison)
        {
            for (int i = 0; i < matrix?.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                    if ((comparison(matrix[i], matrix[j]) < 0))
                        Swap(ref matrix[i], ref matrix[j]);
        }

        private static void Swap(ref int[] firstLine, ref int[] secondLine)
        {
            var tempLine = firstLine;
            firstLine = secondLine;
            secondLine = tempLine;
        }
    }
}
