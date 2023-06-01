using Domain.Enumerations;
using Domain.Interfaces.Base;

namespace Domain.Models.ViewModels;

public class BanksTotalViewModel : IIdentifable<Guid>
{
    private const int EMPTY_BALANCE = 0;

    public BanksTotalViewModel() { }

    public BanksTotalViewModel(Guid id, Bank bank, decimal total)
    {
        Id = id;
        Bank = bank;
        Total = total;
    }

    public Guid Id { get; set; }
    public Bank Bank { get; set; }
    public decimal Total { get; set; }

    public BankViewModel BankModel => new BankViewModel(Bank);
    public string Name => BankModel.Name;

    public bool TotalIsValid() =>
        Total >= EMPTY_BALANCE;
}
