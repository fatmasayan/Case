using Case.Data;
using Case.Models.Comman;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Case.Repository;

public class GenericRepo<TSource> : IGenericRepo<TSource> where TSource : BaseModel
{
    private readonly DataContext _context;

    public GenericRepo(DataContext context)
    {
        _context = context;
    }

    public DbSet<TSource> Table => _context.Set<TSource>();

    public async Task<bool> AddAsync(TSource model)
    {
        try
        {
            var result = EntityState.Added == (await Table.AddAsync(model)).State;

            await _context.SaveChangesAsync();

            return result;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return false;
        }
    }

    public async Task<bool> DeleteAsync(Expression<Func<TSource, bool>> filter)
    {
        try
        {
            var model = await Table.FirstOrDefaultAsync(filter);
            var result = EntityState.Deleted ==  Table.Remove(model).State;

            await _context.SaveChangesAsync();

            return result;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return false;
        }
    }

    public async Task<TSource> GetAsync(Expression<Func<TSource, bool>> filter)
    {
        try
        {
            return await Table.FirstOrDefaultAsync(filter);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return null;
        }
    }

    public async Task<bool> UpdateAsync(TSource model)
    {
        try
        {
            var result = EntityState.Modified == Table.Update(model).State;

            await _context.SaveChangesAsync();

            return result;

        }
        catch (Exception ex)
        {
            // loglama da yapılabilir
            Console.WriteLine(ex.Message);

            return false;
        }
    }
}
