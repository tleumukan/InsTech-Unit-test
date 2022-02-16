using MortgageCalculator.API.Controllers;
using MortgageCalculator.API.DTO;
using MortgageCalculator.API.Enums;
using Xunit;

namespace MortgageCalculator.Tests
{
    public class TestCalculator
    {
        /**
        Test for Monthly Option
        **/
        [Fact]
        public void Test1()
        {
            //Arrange
            var Calculator = new CalculatorController();
            var data = new CalculatorDTO(300000, 5, 20, 5, PaymentSchedule.Monthly);
            const double ans = 4529.1;

            //Act
            var result = Calculator.GetPaymentPerPaymentSchedule(data);

            //Assert
            Assert.Equal(ans, result.Value);
        }
        /**
        Test for Accelerated Options
        **/
        [Fact]
        public void Test2()
        {
            //Arrange
            var Calculator = new CalculatorController();
            var data = new CalculatorDTO(1000000, 10, 20, 5, PaymentSchedule.Accelerated);
            const double ans = 7831.57;

            //Act
            var result = Calculator.GetPaymentPerPaymentSchedule(data);

            //Assert
            Assert.Equal(ans, result.Value);
        }

        /**
        Test for Biweekly Options
        **/
        [Fact]
        public void Test3()
        {
            //Arrange
            var Calculator = new CalculatorController();
            var data = new CalculatorDTO(1000000, 10, 20, 5, PaymentSchedule.BiWeekly);
            const double ans = 8485.24;

            //Act
            var result = Calculator.GetPaymentPerPaymentSchedule(data);

            //Assert
            Assert.Equal(ans, result.Value);
        }
    }
}
