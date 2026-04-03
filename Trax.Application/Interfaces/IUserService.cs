namespace Trax.Application.Interfaces;

using Trax.Domain.Entities;
using Trax.Domain.Enums;

public interface IUserService
{
    Task<IReadOnlyList<AppUser>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<AppUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<AppUser?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<AppUser> CreateOrUpdateUserAsync(AppUser user, CancellationToken cancellationToken = default);
    Task AssignRoleAsync(Guid userId, UserRole role, CancellationToken cancellationToken = default);
}
