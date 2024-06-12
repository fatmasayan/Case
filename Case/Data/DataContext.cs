using Case.Models;
using Case.Models.Comman;
using Microsoft.EntityFrameworkCore;

namespace Case.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<AuthToken> AuthTokens { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseModel>();
        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
