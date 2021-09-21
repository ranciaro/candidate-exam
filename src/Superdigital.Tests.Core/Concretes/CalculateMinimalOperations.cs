
namespace Superdigital.Tests.Core
{
    public class CalculateMinimalOperations : ICalculate<double, int>
    {
        short numberOperations = 0;
        public int Handle(double parameter)
        {
            Reduce(parameter);
            return numberOperations;
        }
        private void Reduce(double parameter)
        {
            while (parameter > 1)
            {
                if (parameter % 2 == 0)
                    parameter = parameter / 2;
                else
                {
                    if (CanDivideResultAfterSubtract(parameter))
                        parameter--;
                    else
                        parameter++;
                }
                numberOperations++;
            }
        }

        private bool CanDivideResultAfterSubtract(double parameter)
        {
            double valor = parameter - 1;
            valor = valor / 2;
            if (valor % 2 == 0)
                return true;
            return false;
        }
    }
}