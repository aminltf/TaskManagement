namespace TaskManagement.Shared.Abstractions;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}
