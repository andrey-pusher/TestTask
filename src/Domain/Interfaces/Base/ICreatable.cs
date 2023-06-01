namespace Domain.Interfaces.Base;

public interface ICreatable<TId, TModel>
    where TId : struct
    where TModel : IIdentifable<TId>
{
    TModel Create(TModel model);
}
