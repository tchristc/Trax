namespace Trax.Application.Specifications.Scheduling;

using Trax.Domain.Entities;
using Trax.Domain.Enums;
using Trax.Domain.Specifications;

public class UpcomingPickupDeliveriesSpec : BaseSpecification<PickupDelivery>
{
    public UpcomingPickupDeliveriesSpec(int days)
        : base(pd => pd.Status == PickupDeliveryStatus.Scheduled
                  && pd.ScheduledDate <= DateTime.UtcNow.AddDays(days))
    {
        AddInclude(pd => pd.Tasks);
        AddInclude(pd => pd.Organization);
        ApplyOrderBy(pd => pd.ScheduledDate);
    }
}
