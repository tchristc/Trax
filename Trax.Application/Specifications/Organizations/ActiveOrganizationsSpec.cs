namespace Trax.Application.Specifications.Organizations;

using Trax.Domain.Entities;
using Trax.Domain.Specifications;

public class ActiveOrganizationsSpec : BaseSpecification<Organization>
{
    public ActiveOrganizationsSpec() : base(o => o.IsActive)
    {
        ApplyOrderBy(o => o.Name);
    }
}
