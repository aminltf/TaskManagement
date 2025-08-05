using TaskManagement.Shared.Abstractions;
using TaskManagement.Shared.Base;

namespace TaskManagement.Domain.Entities;

public class FileAttachment : AuditableEntity<Guid>, ISoftDelete
{
    public Guid TaskId { get; set; } // FK → Task
    public Task Task { get; set; } = default!;
    public string FileName { get; set; } = null!;
    public byte[] Data { get; set; } = default!; // Real File
    public Guid UploadedBy { get; set; } // FK → User
    public User User { get; set; } = default!;
    public bool IsDeleted { get; set; } // Soft Delete

    public FileAttachment() { }

    public FileAttachment(Guid taskId, string fileName, byte[] data, Guid uploadedBy, bool isDeleted)
    {
        TaskId = taskId;
        FileName = fileName;
        Data = data;
        UploadedBy = uploadedBy;
        IsDeleted = isDeleted;
    }
}
