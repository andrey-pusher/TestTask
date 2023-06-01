using Domain.Interfaces.Base;

namespace Domain.Interfaces.Wrappers;

public interface IBanksTotalWrapper<TId, TModel> :
    ICreatable<TId, TModel>,
    IReadable<TId, TModel>,
    IDeletable<TId>
    where TId : struct
    where TModel : IIdentifable<TId>
{
    IEnumerable<TModel> ReadAll();
    TModel Update(TId id, decimal value);
}
