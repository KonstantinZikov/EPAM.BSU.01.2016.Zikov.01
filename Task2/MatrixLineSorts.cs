namespace Task2
{
    public static class MatrixLineSorts
    {
        public static void SortBySum(this int[][] matrix, bool isInAscendingOrder = true) 
        {
            int[] sumArray = new int[matrix.Length];
            for(int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sumArray[i] += matrix[i][j];
                }
            }
            Sort(sumArray, matrix, isInAscendingOrder);
        }

        public static void SortByMaxElement(this int[][] matrix, bool isInAscendingOrder = true)
        {
            int[] maxArray = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (maxArray[i] < matrix[i][j])
                    {
                        maxArray[i] = matrix[i][j];
                    }
                }
            }
            Sort(maxArray, matrix, isInAscendingOrder);
        }

        public static void SortByMinElement(this int[][] matrix, bool isInAscendingOrder = true)
        {
            int[] minArray = new int[matrix.Length];
            
            for (int i = 0; i < matrix.Length; i++)
            {
                minArray[i] = int.MaxValue;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (minArray[i] > matrix[i][j])
                    {
                        minArray[i] = matrix[i][j];
                    }
                }
            }
            Sort(minArray, matrix, isInAscendingOrder);
        }

        private static void Sort(int[] markArray, int[][] matrix, bool isInAscendingOrder)
        {
            for (int i = 0; i < markArray.Length; i++)
            {
                for (int j = 0; j < markArray.Length; j++)
                {
                    if ((markArray[i] < markArray[j]) ^ !isInAscendingOrder)
                    {
                        int tempNum = markArray[i];
                        markArray[i] = markArray[j];
                        markArray[j] = tempNum;

                        int[] tempLine = matrix[i];
                        matrix[i] = matrix[j];
                        matrix[j] = tempLine;
                    }
                }
            }
        }
    }
}
