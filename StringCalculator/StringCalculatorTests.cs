using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTests
    {
        Calculator calculator;

        public StringCalculatorTests()
        {
            calculator = new Calculator(new Mock<ILogger>().Object);
        }

        [Fact]
        public void EmptyStringReturnsZero()
        {
            int answer = calculator.Calculate("");

            Assert.Equal(0, answer);
        }

        [Theory]
        [InlineData("42", 42)]
        [InlineData("17", 17)]
        [InlineData("5", 5)]
        public void OneNumberReturnsTheNumber(string numbers, int expected)
        {
            int answer = calculator.Calculate(numbers);

            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("4,2", 6)]
        [InlineData("1,7", 8)]
        [InlineData("39,3", 42)]
        public void TwoNumbersReturnsTheSum(string numbers, int expected)
        {
            int answer = calculator.Calculate(numbers);

            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("4,2,8", 14)]
        [InlineData("1,1,1,1,1,1,1,1", 8)]
        [InlineData("1,3,5,7,9", 25)]
        public void ThreePlusNumbersReturnsTheSum(string numbers, int expected)
        {
            int answer = calculator.Calculate(numbers);

            Assert.Equal(expected, answer);
        }
    }
}
