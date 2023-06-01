using Domain.Enumerations;
using Domain.Interfaces.Base;

namespace Domain.Models.ViewModels
{
    public class BankViewModel : IIdentifable<Bank>
    {
        public BankViewModel(Bank id)
        {
            Id = id;
        }

        public Bank Id { get; set; }
        public string Name => Id switch
        {
            Bank.VTB => "ВТБ",
            Bank.Sberbank => "Сбербанк",
            Bank.Tinkoff => "Тинькофф",
            Bank.Alfabank => "Альфа-банк",
            Bank.Psbank => "Промсвязьбанк",
            _ => throw new Exception($"Enumeration {nameof(Bank)} contain non-handled values."),
        };
    }
}
