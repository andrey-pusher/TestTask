namespace Domain.Interfaces.Base;

public interface IDeletable<TId> where TId : struct
{
    void Delete(TId id);
}
