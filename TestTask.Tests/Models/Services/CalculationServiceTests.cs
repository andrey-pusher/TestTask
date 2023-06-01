using Domain.Enumerations;
using Domain.Service;
using Xunit;

namespace TestTask.Tests.Models.Services
{
    public class CalculationServiceTests
    {
        [Fact]
        public void FirstBankTotalAddPositive()
        {
            // Arrange
            var bank = Bank.VTB;
            var existed = 100m;
            var offset = 10m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(130m, result);
        }

        [Fact]
        public void FirstBankTotalAddSmallNegative()
        {
            // Arrange
            var bank = Bank.VTB;
            var existed = 100m;
            var offset = -10m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(70m, result);
        }

        [Fact]
        public void FirstBankTotalAddBigNegative()
        {
            // Arrange
            var bank = Bank.VTB;
            var existed = 100m;
            var offset = -50m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(0m, result);
        }

        [Fact]
        public void SecondBankTotalAddSmallPositive()
        {
            // Arrange
            var bank = Bank.Sberbank;
            var existed = 100m;
            var offset = 50m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(75m, result);
        }

        [Fact]
        public void SecondBankTotalAddBigPositive()
        {
            // Arrange
            var bank = Bank.Sberbank;
            var existed = 100m;
            var offset = 210m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(0m, result);
        }

        [Fact]
        public void SecondBankTotalAddNegative()
        {
            // Arrange
            var bank = Bank.Sberbank;
            var existed = 100m;
            var offset = -50m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(125m, result);
        }

        [Fact]
        public void ThirdBankTotalAddSmallNegative()
        {
            // Arrange
            var bank = Bank.Tinkoff;
            var existed = 200m;
            var offset = -50m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(75m, result);
        }

        [Fact]
        public void ThirdBankTotalAddBigNegative()
        {
            // Arrange
            var bank = Bank.Tinkoff;
            var existed = 200m;
            var offset = -250m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(0m, result);
        }

        [Fact]
        public void ThirdBankTotalAddSmallPositive()
        {
            // Arrange
            var bank = Bank.Tinkoff;
            var existed = 50m;
            var offset = 50m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(0m, result);
        }

        [Fact]
        public void ThirdBankTotalAddBigPositive()
        {
            // Arrange
            var bank = Bank.Tinkoff;
            var existed = 50m;
            var offset = 150m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(25m, result);
        }

        [Fact]
        public void OtherBankTotalAddPositive()
        {
            // Arrange
            var bank = Bank.Psbank;
            var existed = 100m;
            var offset = 50m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(150m, result);
        }

        [Fact]
        public void OtherBankTotalAddSmallNegative()
        {
            // Arrange
            var bank = Bank.Psbank;
            var existed = 100m;
            var offset = -50m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(50m, result);
        }

        [Fact]
        public void OtherBankTotalAddBigNegative()
        {
            // Arrange
            var bank = Bank.Psbank;
            var existed = 100m;
            var offset = -250m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.GetValue(bank, existed, offset);

            // Assert
            Assert.Equal(0m, result);
        }
    }
}
