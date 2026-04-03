namespace Trax.Application.Specifications.Inventory;

using Trax.Domain.Entities;
using Trax.Domain.Specifications;

public class ItemsByCategorySpec : BaseSpecification<DonationItem>
{
    public ItemsByCategorySpec(Guid categoryId)
        : base(i => i.CategoryId == categoryId)
    {
        AddInclude(i => i.Category);
        AddInclude(i => i.Donation);
    }
}
