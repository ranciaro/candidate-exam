namespace Superdigital.Tests.Core
{
    public interface ICalculate<ParameterValue, ReturnValue>
    {
         ReturnValue Handle(ParameterValue parameter);
    }
}