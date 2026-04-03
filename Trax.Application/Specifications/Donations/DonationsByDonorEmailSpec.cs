namespace Trax.Application.Specifications.Donations;

using Trax.Domain.Entities;
using Trax.Domain.Specifications;

public class DonationsByDonorEmailSpec : BaseSpecification<Donation>
{
    public DonationsByDonorEmailSpec(string email)
        : base(d => d.DonorEmail.ToLower() == email.ToLower())
    {
        AddInclude(d => d.Items);
        ApplyOrderByDescending(d => d.CreatedAt);
    }
}
