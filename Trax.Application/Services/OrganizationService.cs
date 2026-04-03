namespace Trax.Application.Services;

using Trax.Application.Interfaces;
using Trax.Application.Specifications.Organizations;
using Trax.Domain.Entities;
using Trax.Domain.Interfaces;

public class OrganizationService(IRepository<Organization> repository) : IOrganizationService
{
    public async Task<IReadOnlyList<Organization>> GetAllOrganizationsAsync(CancellationToken cancellationToken = default) =>
        await repository.ListAllAsync(cancellationToken);

    public async Task<IReadOnlyList<Organization>> GetActiveOrganizationsAsync(CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new ActiveOrganizationsSpec(), cancellationToken);

    public async Task<Organization?> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await repository.GetByIdAsync(id, cancellationToken);

    public async Task<Organization> CreateOrganizationAsync(Organization organization, CancellationToken cancellationToken = default) =>
        await repository.AddAsync(organization, cancellationToken);

    public async Task UpdateOrganizationAsync(Organization organization, CancellationToken cancellationToken = default) =>
        await repository.UpdateAsync(organization, cancellationToken);
}
