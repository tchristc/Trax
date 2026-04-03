namespace Trax.Application.Interfaces;

using Trax.Domain.Entities;

public interface IOrganizationService
{
    Task<IReadOnlyList<Organization>> GetAllOrganizationsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Organization>> GetActiveOrganizationsAsync(CancellationToken cancellationToken = default);
    Task<Organization?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Organization> CreateOrganizationAsync(Organization organization, CancellationToken cancellationToken = default);
    Task UpdateOrganizationAsync(Organization organization, CancellationToken cancellationToken = default);
}
