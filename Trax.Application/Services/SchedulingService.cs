namespace Trax.Application.Services;

using Trax.Application.Interfaces;
using Trax.Application.Specifications.Scheduling;
using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Interfaces;

public class SchedulingService(
    IRepository<PickupDelivery> pickupDeliveryRepository,
    IRepository<VolunteerTask> volunteerTaskRepository) : ISchedulingService
{
    public async Task<IReadOnlyList<PickupDelivery>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await pickupDeliveryRepository.ListAllAsync(cancellationToken);

    public async Task<IReadOnlyList<PickupDelivery>> GetByStatusAsync(PickupDeliveryStatus status, CancellationToken cancellationToken = default) =>
        await pickupDeliveryRepository.ListAsync(new PickupDeliveriesByStatusSpec(status), cancellationToken);

    public async Task<IReadOnlyList<PickupDelivery>> GetUpcomingAsync(int days = 7, CancellationToken cancellationToken = default) =>
        await pickupDeliveryRepository.ListAsync(new UpcomingPickupDeliveriesSpec(days), cancellationToken);

    public async Task<PickupDelivery> SchedulePickupAsync(PickupDelivery pickup, CancellationToken cancellationToken = default) =>
        await pickupDeliveryRepository.AddAsync(pickup, cancellationToken);

    public async Task<PickupDelivery> ScheduleDeliveryAsync(PickupDelivery delivery, CancellationToken cancellationToken = default) =>
        await pickupDeliveryRepository.AddAsync(delivery, cancellationToken);

    public async Task AssignVolunteerAsync(Guid pickupDeliveryId, Guid volunteerId, CancellationToken cancellationToken = default)
    {
        var task = new VolunteerTask
        {
            PickupDeliveryId = pickupDeliveryId,
            VolunteerId = volunteerId
        };
        await volunteerTaskRepository.AddAsync(task, cancellationToken);
    }

    public async Task UpdateStatusAsync(Guid id, PickupDeliveryStatus status, CancellationToken cancellationToken = default)
    {
        var pd = await pickupDeliveryRepository.GetByIdAsync(id, cancellationToken);
        if (pd is null) return;
        pd.Status = status;
        await pickupDeliveryRepository.UpdateAsync(pd, cancellationToken);
    }
}
