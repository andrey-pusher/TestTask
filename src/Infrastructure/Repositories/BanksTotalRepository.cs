using Domain.Interfaces.Exteranal.Repositories;
using Domain.Models.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BanksTotalRepository : IBanksTotalRepository<Guid, BanksTotal>
{
    private readonly TestTaskContext _context;

    public BanksTotalRepository(TestTaskContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public BanksTotal Read(Guid id)
    {
        var existed = _context.BanksTotals
            .AsNoTracking()
            .FirstOrDefault(banksTotal => banksTotal.Id == id);

        if (existed is null)
        {
            throw new Exception($"Cannot find non-existent entity with id {id}.");
        }

        return existed;
    }
    public IEnumerable<BanksTotal> ReadAll() =>
        _context.BanksTotals.OrderBy(banksTotal => banksTotal.Bank).AsNoTracking();

    public BanksTotal Update(BanksTotal model)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        var existed = Read(model.Id);

        existed.Total = model.Total;

        _context.BanksTotals.Update(existed);
        _context.SaveChanges();

        return existed;
    }

    public void Delete(Guid id)
    {
        var existed = Read(id);
        existed.Total = 0m;

        Update(existed);
    }    
}
