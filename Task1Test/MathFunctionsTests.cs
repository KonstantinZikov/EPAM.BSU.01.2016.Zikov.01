using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Test
{
    [TestClass]
    public class MathFunctionsTest
    {
        [TestMethod]
        public void Root_SquareRootOf25_Returns5()
        {
            //arrange
            double number = 25;
            double power = 2;
            double expectedResult = 5;

            //act
            double actualResult = MathFunctions.Root(number, power);

            //assert
            Assert.IsTrue
            (
                Math.Abs(expectedResult - actualResult) < MathFunctions.RootAccuracy
            );
        }

        [TestMethod]
        public void Root_14RootOf4242_ReturnsTheSameResultLikeMathPow()
        {
            //arrange
            double number = 4242;
            double power = 14;

            //act
            double expectedResult = Math.Pow(number,1/power);
            double actualResult = MathFunctions.Root(number, power);

            //assert
            Assert.IsTrue
            (
                Math.Abs(expectedResult - actualResult) < MathFunctions.RootAccuracy
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_NumberLessThenNull_ArgumentExceptionExpected()
        {
            //arrange
            double number = -42;
            double power = 3;

            //act
            MathFunctions.Root(number, power);

            //assert is handled by exception
        }

        [TestMethod]
        public void Root_PowerLessThenNull_ReturnsTheSameResultLikeMathPow()
        {
            //arrange
            double number = 713;
            double power = -6;

            //act
            double expectedResult = Math.Pow(number, 1 / power);
            double actualResult = MathFunctions.Root(number, power);

            //assert
            Assert.IsTrue
            (
                Math.Abs(expectedResult - actualResult) < MathFunctions.RootAccuracy
            );
        }
    }
}
