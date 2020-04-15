using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        internal int Calculate(string v)
        {
            int answer;

            if (v == String.Empty)
            {
                answer = 0;
            } else
            {
                var numbers = v.Split(",").Select(s => int.Parse(s));
                answer = numbers.Sum();
            }

            _logger.Write(answer);
            return answer;
        }
    }
}