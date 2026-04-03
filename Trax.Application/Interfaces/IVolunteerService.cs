namespace Trax.Application.Interfaces;

using Trax.Domain.Entities;

public interface IVolunteerService
{
    Task<IReadOnlyList<Volunteer>> GetAllVolunteersAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Volunteer>> GetActiveVolunteersAsync(CancellationToken cancellationToken = default);
    Task<Volunteer?> GetVolunteerByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Volunteer?> GetVolunteerByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Volunteer> CreateVolunteerAsync(Volunteer volunteer, CancellationToken cancellationToken = default);
    Task UpdateVolunteerAsync(Volunteer volunteer, CancellationToken cancellationToken = default);
}
