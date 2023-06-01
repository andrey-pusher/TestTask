using Domain.Enumerations;
using Domain.Models.ViewModels;
using Xunit;

namespace TestTask.Tests.Models.ViewModels;

public class BanksTotalTests
{
    [Fact]
    public void TotalIsValidWhenCreating()
    {
        // Arrange
        Guid Id = Guid.NewGuid();
        Bank bank = Bank.Sberbank;
        decimal total = 200m;

        BanksTotalViewModel viewModelOnUpdate = new BanksTotalViewModel(Id, bank, total);

        // Act
        bool totalIsValid = viewModelOnUpdate.TotalIsValid();

        // Assert
        Assert.True(totalIsValid);
    }

    [Fact]
    public void TotalIsNotValidWhenCreating()
    {
        // Arrange
        Guid Id = Guid.NewGuid();
        Bank bank = Bank.Sberbank;
        decimal total = -10m;

        BanksTotalViewModel viewModelOnUpdate = new BanksTotalViewModel(Id, bank, total);

        // Act
        bool totalIsValid = viewModelOnUpdate.TotalIsValid();

        // Assert
        Assert.False(totalIsValid);
    }
}
