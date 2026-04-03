namespace Trax.Domain.Entities;

using Trax.Domain.Common;

public class ItemCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<DonationItem> DonationItems { get; set; } = new List<DonationItem>();
}
