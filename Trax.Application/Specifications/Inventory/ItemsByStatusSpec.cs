namespace Trax.Application.Specifications.Inventory;

using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Specifications;

public class ItemsByStatusSpec : BaseSpecification<DonationItem>
{
    public ItemsByStatusSpec(ItemStatus status)
        : base(i => i.Status == status)
    {
        AddInclude(i => i.Category);
        AddInclude(i => i.Donation);
    }
}
