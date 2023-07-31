using GeicoRateCalculator.Request;

namespace GeicoRateCalculator.Services
{
    public class RatesCalculatorService : IRatesCalculatorService
    {

        Dictionary<decimal, Tuple<decimal, decimal>> rates;
        public float WomenDiscount { get; set; }
        public float  UnderAgePremium { get; set; }
        public RatesCalculatorService()
        {
            rates = new Dictionary<decimal, Tuple<decimal,decimal>>(); 
            rates.Add(11000, new Tuple<decimal, decimal>(50,10));
            rates.Add(25000, new Tuple<decimal, decimal>(100,12));
            rates.Add(50000, new Tuple<decimal, decimal>(100,15));
            //Value  Premium
            // 11 50
            // 25 100

            WomenDiscount = 0f;
            UnderAgePremium = 0.1f;

        }
        public float CalculateRateAsync(User user, Car car )
        {
            var val = car.Value;

            float premium = 0f;

            
            //1 Cost of Car
            foreach (var item in rates.Keys)
            {
                if (item > val)
                {
                    premium += (float)rates[item].Item1;
                    WomenDiscount =(float) rates[item].Item2;
                    break;
                }
            }

            //2 Gender

            if (user.Sex == "F") premium -= WomenDiscount;

            //3 Age
            if(user.Age <25)
            {
                var addedPremium = premium + (premium * UnderAgePremium);
                premium = addedPremium;
            }


            // Can move each of these rules into a separate Service.
            
            return premium;
        }
    }
}
