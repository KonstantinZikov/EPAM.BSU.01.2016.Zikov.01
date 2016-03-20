using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class MatrixLineComparer
    {
        public int Compare(int[] firstLine, int[] secondLine)
        {
            return CompareFunction(firstLine) - CompareFunction(secondLine);
        }

        public abstract int CompareFunction(int[] line);
    }
}
