using Domain.Extensions;
using Domain.Interfaces.Exteranal.Repositories;
using Domain.Interfaces.Wrappers;
using Domain.Mappers;
using Domain.Models.Entities;
using Domain.Models.ViewModels;
using Domain.Service;

namespace Domain.Wrappers;

public class BanksTotalWrapper : IBanksTotalWrapper<Guid, BanksTotalViewModel>
{
    private readonly IBanksTotalRepository<Guid, BanksTotal> _banksTotalRepository;
    private readonly CalculationService _calculationService;

    public BanksTotalWrapper(IBanksTotalRepository<Guid, BanksTotal> banksTotalRepository)
    {
        _banksTotalRepository = banksTotalRepository
            ?? throw new ArgumentNullException(nameof(banksTotalRepository));
        _calculationService = new CalculationService();
    }

    public BanksTotalViewModel Create(BanksTotalViewModel viewModel)
    {
        viewModel.ThrowExceptionIfNull();

        var existedTotal = _banksTotalRepository.Read(viewModel.Id);
        var newBalance = _calculationService.GetValue(viewModel.Bank, existedTotal.Total, viewModel.Total);

        viewModel.Total = newBalance;

        if (viewModel.TotalIsValid())
        {
            var createdEntity = _banksTotalRepository.Update(viewModel.ToEntity());

            return createdEntity.ToViewModel();
        }
        else
        {
            throw new Exception("Insufficient funds for the operation");
        }
    }

    public IEnumerable<BanksTotalViewModel> ReadAll() =>
        _banksTotalRepository.ReadAll().ToViewModels();

    public BanksTotalViewModel Read(Guid id) =>
        _banksTotalRepository.Read(id).ToViewModel();

    public BanksTotalViewModel Update(Guid id, decimal value)
    {
        var entity = _banksTotalRepository.Read(id);
        var viewModel = new BanksTotalViewModel(id, entity.Bank, value);

        if (viewModel.TotalIsValid())
        {
            var updatedEntity = _banksTotalRepository.Update(viewModel.ToEntity());

            return updatedEntity.ToViewModel();
        }
        else
        {
            throw new Exception("The withdrawal amount exceeds the balance");
        }
    }

    public void Delete(Guid id) =>
    _banksTotalRepository.Delete(id);
}