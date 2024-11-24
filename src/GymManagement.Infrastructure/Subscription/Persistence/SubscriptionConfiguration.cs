using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Subscription.Persistence;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Domain.Subscriptions.Subscription>
{
    public void Configure(EntityTypeBuilder<Domain.Subscriptions.Subscription> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever();
        builder.Property("_adminId").HasColumnName("AdminId");
        builder.Property(s => s.SubscriptionType).HasConversion(
            subscriptionType => subscriptionType.Value,
            value => SubscriptionType.FromValue(value)
        );

    }
}