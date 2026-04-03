namespace Trax.Application.Specifications.Volunteers;

using Trax.Domain.Entities;
using Trax.Domain.Specifications;

public class ActiveVolunteersSpec : BaseSpecification<Volunteer>
{
    public ActiveVolunteersSpec() : base(v => v.IsActive)
    {
        AddInclude(v => v.AppUser);
        ApplyOrderBy(v => v.LastName);
    }
}
