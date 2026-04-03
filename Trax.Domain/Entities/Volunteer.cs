namespace Trax.Domain.Entities;

using Trax.Domain.Common;

public class Volunteer : BaseEntity
{
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
    public ICollection<VolunteerTask> Tasks { get; set; } = new List<VolunteerTask>();
}
