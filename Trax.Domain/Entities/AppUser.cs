namespace Trax.Domain.Entities;

using Trax.Domain.Common;
using Trax.Domain.Enums;

public class AppUser : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.None;
    public Volunteer? Volunteer { get; set; }
}
