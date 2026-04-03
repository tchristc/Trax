namespace Trax.Domain.Entities;

using Trax.Domain.Common;
using Trax.Domain.Enums;

public class VolunteerTask : BaseEntity
{
    public Guid VolunteerId { get; set; }
    public Volunteer Volunteer { get; set; } = null!;
    public Guid PickupDeliveryId { get; set; }
    public PickupDelivery PickupDelivery { get; set; } = null!;
    public VolunteerTaskStatus Status { get; set; } = VolunteerTaskStatus.Assigned;
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }
    public string? Notes { get; set; }
}
