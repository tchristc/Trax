namespace Trax.Application.Interfaces;

using Trax.Domain.Entities;
using Trax.Domain.Enums;

public interface IDonationService
{
    Task<IReadOnlyList<Donation>> GetAllDonationsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Donation>> GetDonationsByStatusAsync(DonationStatus status, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Donation>> GetDonationsByDonorEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<Donation?> GetDonationByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Donation> CreateDonationAsync(Donation donation, CancellationToken cancellationToken = default);
    Task UpdateDonationAsync(Donation donation, CancellationToken cancellationToken = default);
    Task UpdateDonationStatusAsync(Guid id, DonationStatus status, CancellationToken cancellationToken = default);
    Task DeleteDonationAsync(Guid id, CancellationToken cancellationToken = default);
}
