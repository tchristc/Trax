namespace Trax.Application.Specifications.Users;

using Trax.Domain.Entities;
using Trax.Domain.Specifications;

public class UserByEmailSpec : BaseSpecification<AppUser>
{
    public UserByEmailSpec(string email)
        : base(u => u.Email.ToLower() == email.ToLower()) { }
}
