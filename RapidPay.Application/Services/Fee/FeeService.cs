using System;

namespace RapidPay.Application.Services.Fee
{
    public class FeeService : IFeeService
    {

        private DateTime LastGenerationFeeTime { get; set; }
        private decimal Fee { get; set; }
        private decimal LastFeeValue { get; set; } = Convert.ToDecimal(0);

        public FeeService()
        {

            LastGenerationFeeTime = DateTime.Now;
            var rand = new Random();
            var fee = Convert.ToDecimal(rand.NextDouble() * rand.Next(0, 2));
            Fee = fee;
        }
        public decimal GetFee()
        {
            var now = DateTime.Now;

            if (
                LastGenerationFeeTime.Day == now.Day &&
                LastGenerationFeeTime.Hour == now.Hour &&
                Fee != Convert.ToDecimal(0))
            {
                return Fee;
            }

            var rand = new Random();

            var fee = Convert.ToDecimal(rand.NextDouble() * rand.Next(0, 2));
            LastFeeValue = Fee;
            Fee = fee * (
                LastFeeValue == Convert.ToDecimal(0) ?
                1 :
                LastFeeValue);

            LastGenerationFeeTime = now;

            return fee;

        }

        public decimal GetLastFeeAmount()
        {
            return LastFeeValue;
        }
    }
}
