using Domain.Interfaces.Base;

namespace Domain.Interfaces.Exteranal.Repositories
{
    public interface IBanksTotalRepository<TId, TModel> :
    IReadable<TId, TModel>,
    IUpdatable<TId, TModel>,
    IDeletable<TId>
    where TId : struct
    where TModel : IIdentifable<TId>
    {
        IEnumerable<TModel> ReadAll();
    }
}
