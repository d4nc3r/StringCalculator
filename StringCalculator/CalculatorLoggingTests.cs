using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculator
{
    public class CalculatorLoggingTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("42", 42)]
        [InlineData("1,3,5,7,9", 25)]
        public void CalculationIsLogged(string numbers, int expected)
        {
            var writeMock = new Mock<ILogger>();
            var calculator = new Calculator(writeMock.Object);
            int answer = calculator.Calculate(numbers);

            writeMock.Verify(m => m.Write(expected));
        }
    }
}
