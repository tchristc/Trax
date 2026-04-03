namespace Trax.Application.Services;

using Trax.Application.Interfaces;
using Trax.Application.Specifications.Users;
using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Interfaces;

public class UserService(IRepository<AppUser> repository) : IUserService
{
    public async Task<IReadOnlyList<AppUser>> GetAllUsersAsync(CancellationToken cancellationToken = default) =>
        await repository.ListAllAsync(cancellationToken);

    public async Task<AppUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default) =>
        await repository.FirstOrDefaultAsync(new UserByEmailSpec(email), cancellationToken);

    public async Task<AppUser?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await repository.GetByIdAsync(id, cancellationToken);

    public async Task<AppUser> CreateOrUpdateUserAsync(AppUser user, CancellationToken cancellationToken = default)
    {
        var existing = await repository.FirstOrDefaultAsync(new UserByEmailSpec(user.Email), cancellationToken);
        if (existing is not null)
        {
            existing.DisplayName = user.DisplayName;
            await repository.UpdateAsync(existing, cancellationToken);
            return existing;
        }
        return await repository.AddAsync(user, cancellationToken);
    }

    public async Task AssignRoleAsync(Guid userId, UserRole role, CancellationToken cancellationToken = default)
    {
        var user = await repository.GetByIdAsync(userId, cancellationToken);
        if (user is null) return;
        user.Role = role;
        await repository.UpdateAsync(user, cancellationToken);
    }
}
