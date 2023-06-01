using Domain.Models.Entities;
using Domain.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Conficurations;

public class BanksTotalConfiguration : IEntityTypeConfiguration<BanksTotal>
{
    public void Configure(EntityTypeBuilder<BanksTotal> builder)
    {
        builder.ToTable("banks_total");

        builder.Property(banksTotal => banksTotal.Id).HasColumnName("id");
        builder.Property(banksTotal => banksTotal.Bank).HasColumnName("bank");
        builder.Property(banksTotal => banksTotal.Total).HasColumnName("total");

        var banksList = new BankListViewModel();
        var initialTotal = 0m;

        var initialData = banksList.Banks
            .ToList()
            .Select(bankModel => new BanksTotal(Guid.NewGuid(), bankModel.Id, initialTotal));

        builder.HasData(initialData);
    }
}
