namespace Trax.Domain.Entities;

using Trax.Domain.Common;
using Trax.Domain.Enums;

public class PickupDelivery : BaseEntity
{
    public PickupDeliveryType Type { get; set; }
    public DateTime ScheduledDate { get; set; }
    public PickupDeliveryStatus Status { get; set; } = PickupDeliveryStatus.Scheduled;
    public string? Address { get; set; }
    public string? Notes { get; set; }
    public Guid? DonationId { get; set; }
    public Donation? Donation { get; set; }
    public Guid? OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    public ICollection<VolunteerTask> Tasks { get; set; } = new List<VolunteerTask>();
}
