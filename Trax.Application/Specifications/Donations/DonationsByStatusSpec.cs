namespace Trax.Application.Specifications.Donations;

using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Specifications;

public class DonationsByStatusSpec : BaseSpecification<Donation>
{
    public DonationsByStatusSpec(DonationStatus status)
        : base(d => d.Status == status)
    {
        AddInclude(d => d.Items);
        ApplyOrderByDescending(d => d.CreatedAt);
    }
}
