using System;
using MortgageCalculator.API.DTO;
using MortgageCalculator.API.Enums;

namespace MortgageCalculator.API.Util
{
    public class CalculatePayment
    {
        //Property price
        private double P { get; set; }
        //Per payment schedule interest rate
        private double R { get; set; }
        //Total number of payments over amortization period
        private int N { get; set; }

        public CalculatePayment(CalculatorDTO input)
        {
            this.P = input.PropertyPrice - CalculateDownPayment(input.DownPaymentRate, input.PropertyPrice);
            this.R = CalculatePaymentScheduleInterestRate(input.AnnualInterestRate, input.PaymentScheduleOptions);
            this.N = totalPayments(input.PaymentScheduleOptions, input.AmortizationPeriod);
        }
        private double CalculatePaymentScheduleInterestRate(double annualInterestRate, PaymentSchedule options)
        {
            return (annualInterestRate / 100) / (int)options;
        }
        private int totalPayments(PaymentSchedule options, int period)
        {
            return (int)options * period;
        }
        private double CalculateDownPayment(double downPaymentPercentage, double propertyPrice)
        {
            return propertyPrice * (downPaymentPercentage / 100);
        }


        /**
          return the payment per payment schedule
        **/
        public double CalculatePaymentPerPaymentSchedule()
        {
            double numerator = P * R * Math.Pow((1 + R), N);
            double denomnator = Math.Pow((1 + R), N) - 1;
            return Math.Round(numerator / denomnator, 2);
        }
    }
}