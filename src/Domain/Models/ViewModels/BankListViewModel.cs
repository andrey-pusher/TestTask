using Domain.Enumerations;

namespace Domain.Models.ViewModels
{
    public class BankListViewModel
    {
        public IEnumerable<BankViewModel> Banks =>
            Enum.GetValues(typeof(Bank))
                .Cast<Bank>()
                .Select(bank => new BankViewModel(bank));
    }
}
