namespace Task2
{
    public static class MatrixLineSorts
    {
        public static void Sort(this int[][] matrix, MatrixLineComparer comparer, bool isInAscendingOrder = true)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    var comparingResult = comparer.Compare(matrix[i], matrix[j]);
                    if ((comparingResult < 0) ^ !isInAscendingOrder)
                    {
                        Swap(ref matrix[i], ref matrix[j]);
                    }
                }
            }
        }

        private static void Swap(ref int[] firstLine, ref int[] secondLine)
        {
            var tempLine = firstLine;
            firstLine = secondLine;
            secondLine = tempLine;
        }
    }
}
