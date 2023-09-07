using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Paging
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int currentIndex, int size , int from=0, CancellationToken cancellationToken = default)
        {
            if (from > currentIndex) throw new ArgumentException($"From: {from} can not be bigger than {currentIndex}");
            int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            List<T> products = await source.Skip((currentIndex - from) * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);
            Paginate<T> list = new()
            {
                Index = currentIndex,
                Size = size,
                From = from,
                Count = count,
                Items = products,
                Pages = (int)Math.Ceiling(count / (double)size)
            };
            return list;
        }
    }
}
