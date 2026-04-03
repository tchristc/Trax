namespace Trax.Domain.Entities;

using Trax.Domain.Common;
using Trax.Domain.Enums;

public class Donation : BaseEntity
{
    public string DonorName { get; set; } = string.Empty;
    public string DonorEmail { get; set; } = string.Empty;
    public string? DonorPhone { get; set; }
    public string? PickupAddress { get; set; }
    public DateTime DateReceived { get; set; }
    public DonationStatus Status { get; set; } = DonationStatus.Pending;
    public string? Notes { get; set; }
    public ICollection<DonationItem> Items { get; set; } = new List<DonationItem>();
    public PickupDelivery? PickupDelivery { get; set; }
}
