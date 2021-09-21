using System;

namespace Superdigital.Tests.Core
{
    public class CalculatePrimeNumber : ICalculate<int, string>
    {
        private const int IndexSum = 5;
        private string primeNumbers = string.Empty;
        public string Handle(int parameter)
        {
            CalculatePrimeNumbersUntilIndex(parameter);
            return GetPrimeNumberAtIndex(parameter);
        }

        private void CalculatePrimeNumbersUntilIndex(int index)
        {
            for(int count = 2; primeNumbers.Length <= index + 5; count ++)
            {
                if(IsPrimeNumber(count))
                    primeNumbers += count.ToString();
            }
        }

        private bool IsPrimeNumber(int number)
        {
            if(number <= 1) 
                return false;

            for(int count = 2; count < number; count++)
            {
                if(number % count  == 0)
                    return false;
            }
            return true;
        }

        private string GetPrimeNumberAtIndex(int index)
        {
            int indexLimit = index + IndexSum;
            return primeNumbers[index..indexLimit];
        }
    }
}