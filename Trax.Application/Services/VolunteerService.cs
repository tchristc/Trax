namespace Trax.Application.Services;

using Trax.Application.Interfaces;
using Trax.Application.Specifications.Volunteers;
using Trax.Domain.Entities;
using Trax.Domain.Interfaces;

public class VolunteerService(IRepository<Volunteer> repository) : IVolunteerService
{
    public async Task<IReadOnlyList<Volunteer>> GetAllVolunteersAsync(CancellationToken cancellationToken = default) =>
        await repository.ListAllAsync(cancellationToken);

    public async Task<IReadOnlyList<Volunteer>> GetActiveVolunteersAsync(CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new ActiveVolunteersSpec(), cancellationToken);

    public async Task<Volunteer?> GetVolunteerByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await repository.GetByIdAsync(id, cancellationToken);

    public async Task<Volunteer?> GetVolunteerByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        await repository.FirstOrDefaultAsync(new VolunteerByUserIdSpec(userId), cancellationToken);

    public async Task<Volunteer> CreateVolunteerAsync(Volunteer volunteer, CancellationToken cancellationToken = default) =>
        await repository.AddAsync(volunteer, cancellationToken);

    public async Task UpdateVolunteerAsync(Volunteer volunteer, CancellationToken cancellationToken = default) =>
        await repository.UpdateAsync(volunteer, cancellationToken);
}
