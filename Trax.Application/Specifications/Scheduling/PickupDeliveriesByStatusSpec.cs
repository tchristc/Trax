namespace Trax.Application.Specifications.Scheduling;

using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Specifications;

public class PickupDeliveriesByStatusSpec : BaseSpecification<PickupDelivery>
{
    public PickupDeliveriesByStatusSpec(PickupDeliveryStatus status)
        : base(pd => pd.Status == status)
    {
        AddInclude(pd => pd.Tasks);
        AddInclude(pd => pd.Organization);
        ApplyOrderBy(pd => pd.ScheduledDate);
    }
}
