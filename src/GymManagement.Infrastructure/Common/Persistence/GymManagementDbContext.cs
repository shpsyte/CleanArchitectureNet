using GymManagement.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

internal class GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Domain.Subscriptions.Subscription> Subscriptions { get; set; } = null!;
    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}