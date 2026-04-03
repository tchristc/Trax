namespace Trax.Application.Specifications.Volunteers;

using Trax.Domain.Entities;
using Trax.Domain.Specifications;

public class VolunteerByUserIdSpec : BaseSpecification<Volunteer>
{
    public VolunteerByUserIdSpec(Guid userId)
        : base(v => v.AppUserId == userId)
    {
        AddInclude(v => v.AppUser);
        AddInclude(v => v.Tasks);
    }
}
