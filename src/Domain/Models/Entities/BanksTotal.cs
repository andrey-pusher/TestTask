using Domain.Enumerations;
using Domain.Interfaces.Base;

namespace Domain.Models.Entities;

public class BanksTotal : IIdentifable<Guid>
{
    public BanksTotal(Guid id, Bank bank, decimal total)
    {
        Id = id;
        Bank = bank;
        Total = total;
    }

    public Guid Id { get; set; }
    public Bank Bank { get; set; }
    public decimal Total { get; set; }
}
