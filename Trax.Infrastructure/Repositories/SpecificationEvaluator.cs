namespace Trax.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Trax.Domain.Common;
using Trax.Domain.Interfaces;

internal static class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        query = spec.Includes.Aggregate(query, (q, include) => q.Include(include));
        query = spec.IncludeStrings.Aggregate(query, (q, include) => q.Include(include));

        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);
        else if (spec.OrderByDescending != null)
            query = query.OrderByDescending(spec.OrderByDescending);

        if (spec.IsPagingEnabled)
            query = query.Skip(spec.Skip).Take(spec.Take);

        return query;
    }
}
