namespace Trax.Domain.Entities;

using Trax.Domain.Common;
using Trax.Domain.Enums;

public class DonationItem : BaseEntity
{
    public Guid DonationId { get; set; }
    public Donation Donation { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public ItemCategory Category { get; set; } = null!;
    public ItemCondition Condition { get; set; }
    public int Quantity { get; set; } = 1;
    public ItemStatus Status { get; set; } = ItemStatus.Donated;
    public Guid? ReservedForOrganizationId { get; set; }
    public Organization? ReservedForOrganization { get; set; }
    public string? Notes { get; set; }
}
