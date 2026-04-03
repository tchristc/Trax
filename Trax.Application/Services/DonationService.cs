namespace Trax.Application.Services;

using Trax.Application.Interfaces;
using Trax.Application.Specifications.Donations;
using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Interfaces;

public class DonationService(IRepository<Donation> repository) : IDonationService
{
    public async Task<IReadOnlyList<Donation>> GetAllDonationsAsync(CancellationToken cancellationToken = default) =>
        await repository.ListAllAsync(cancellationToken);

    public async Task<IReadOnlyList<Donation>> GetDonationsByStatusAsync(DonationStatus status, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new DonationsByStatusSpec(status), cancellationToken);

    public async Task<IReadOnlyList<Donation>> GetDonationsByDonorEmailAsync(string email, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new DonationsByDonorEmailSpec(email), cancellationToken);

    public async Task<Donation?> GetDonationByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await repository.GetByIdAsync(id, cancellationToken);

    public async Task<Donation> CreateDonationAsync(Donation donation, CancellationToken cancellationToken = default) =>
        await repository.AddAsync(donation, cancellationToken);

    public async Task UpdateDonationAsync(Donation donation, CancellationToken cancellationToken = default) =>
        await repository.UpdateAsync(donation, cancellationToken);

    public async Task UpdateDonationStatusAsync(Guid id, DonationStatus status, CancellationToken cancellationToken = default)
    {
        var donation = await repository.GetByIdAsync(id, cancellationToken);
        if (donation is null) return;
        donation.Status = status;
        await repository.UpdateAsync(donation, cancellationToken);
    }

    public async Task DeleteDonationAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var donation = await repository.GetByIdAsync(id, cancellationToken);
        if (donation is null) return;
        await repository.DeleteAsync(donation, cancellationToken);
    }
}
