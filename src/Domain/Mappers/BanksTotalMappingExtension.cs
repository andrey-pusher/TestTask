using Domain.Models.Entities;
using Domain.Models.ViewModels;

namespace Domain.Mappers
{
    public static class BanksTotalMappingExtension
    {
        public static BanksTotal ToEntity(this BanksTotalViewModel viewModel) =>
            new BanksTotal(viewModel.Id, viewModel.Bank, viewModel.Total);

        public static BanksTotalViewModel ToViewModel(this BanksTotal entity) =>
            new BanksTotalViewModel(entity.Id, entity.Bank, entity.Total);

        public static IEnumerable<BanksTotalViewModel> ToViewModels(
            this IEnumerable<BanksTotal> entities) =>
            entities.Select(ToViewModel);
    }
}
