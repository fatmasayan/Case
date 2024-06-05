using Case.Models.Comman;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Case.Repository
{
    public interface IGenericRepo<TSource> where TSource :BaseModel
    {
        DbSet<TSource> Table { get; }

        Task<bool> AddAsync(TSource model);
        Task<bool> UpdateAsync(TSource model);
        Task<bool> DeleteAsync(Expression<Func<TSource, bool>> filter);
        Task<TSource> GetAsync(Expression<Func<TSource, bool>> filter);

    }
}
