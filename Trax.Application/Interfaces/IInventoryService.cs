namespace Trax.Application.Interfaces;

using Trax.Domain.Entities;
using Trax.Domain.Enums;

public interface IInventoryService
{
    Task<IReadOnlyList<DonationItem>> GetAllItemsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DonationItem>> GetItemsByStatusAsync(ItemStatus status, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DonationItem>> GetItemsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ItemCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    Task UpdateItemStatusAsync(Guid itemId, ItemStatus status, CancellationToken cancellationToken = default);
    Task ReserveItemForOrganizationAsync(Guid itemId, Guid organizationId, CancellationToken cancellationToken = default);
}
