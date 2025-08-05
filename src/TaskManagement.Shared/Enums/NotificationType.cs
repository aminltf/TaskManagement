using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Shared.Enums;

public enum NotificationType
{
    [Display(Name = "Task Assigned")]
    TaskAssigned = 1,

    [Display(Name = "Task Updated")]
    TaskUpdated = 2,

    [Display(Name = "System Message")]
    SystemMessage = 3
}
