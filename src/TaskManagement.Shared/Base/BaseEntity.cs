using TaskManagement.Shared.Abstractions;

namespace TaskManagement.Shared.Base;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;
}
