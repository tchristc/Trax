namespace Trax.Application.Services;

using Trax.Application.Interfaces;
using Trax.Application.Specifications.Inventory;
using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Interfaces;

public class InventoryService(
    IRepository<DonationItem> itemRepository,
    IRepository<ItemCategory> categoryRepository) : IInventoryService
{
    public async Task<IReadOnlyList<DonationItem>> GetAllItemsAsync(CancellationToken cancellationToken = default) =>
        await itemRepository.ListAllAsync(cancellationToken);

    public async Task<IReadOnlyList<DonationItem>> GetItemsByStatusAsync(ItemStatus status, CancellationToken cancellationToken = default) =>
        await itemRepository.ListAsync(new ItemsByStatusSpec(status), cancellationToken);

    public async Task<IReadOnlyList<DonationItem>> GetItemsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default) =>
        await itemRepository.ListAsync(new ItemsByCategorySpec(categoryId), cancellationToken);

    public async Task<IReadOnlyList<ItemCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default) =>
        await categoryRepository.ListAllAsync(cancellationToken);

    public async Task UpdateItemStatusAsync(Guid itemId, ItemStatus status, CancellationToken cancellationToken = default)
    {
        var item = await itemRepository.GetByIdAsync(itemId, cancellationToken);
        if (item is null) return;
        item.Status = status;
        await itemRepository.UpdateAsync(item, cancellationToken);
    }

    public async Task ReserveItemForOrganizationAsync(Guid itemId, Guid organizationId, CancellationToken cancellationToken = default)
    {
        var item = await itemRepository.GetByIdAsync(itemId, cancellationToken);
        if (item is null) return;
        item.ReservedForOrganizationId = organizationId;
        item.Status = ItemStatus.Reserved;
        await itemRepository.UpdateAsync(item, cancellationToken);
    }
}
