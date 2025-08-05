namespace TaskManagement.Shared.Abstractions;

public interface IBaseEntity<TKey>
{
    TKey Id { get; set; }
}
