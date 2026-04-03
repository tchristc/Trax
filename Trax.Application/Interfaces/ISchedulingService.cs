namespace Trax.Application.Interfaces;

using Trax.Domain.Entities;
using Trax.Domain.Enums;

public interface ISchedulingService
{
    Task<IReadOnlyList<PickupDelivery>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PickupDelivery>> GetByStatusAsync(PickupDeliveryStatus status, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PickupDelivery>> GetUpcomingAsync(int days = 7, CancellationToken cancellationToken = default);
    Task<PickupDelivery> SchedulePickupAsync(PickupDelivery pickup, CancellationToken cancellationToken = default);
    Task<PickupDelivery> ScheduleDeliveryAsync(PickupDelivery delivery, CancellationToken cancellationToken = default);
    Task AssignVolunteerAsync(Guid pickupDeliveryId, Guid volunteerId, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(Guid id, PickupDeliveryStatus status, CancellationToken cancellationToken = default);
}
