using GeicoRateCalculator.Request;

namespace GeicoRateCalculator.Services
{
    public interface IRatesCalculatorService
    {
       public float CalculateRateAsync(User user, Car car);
    }
}