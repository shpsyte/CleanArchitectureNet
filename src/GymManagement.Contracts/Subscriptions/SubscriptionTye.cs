using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace GymManagement.Contracts.Subscriptions;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionTye
{
    Free,
    Starter,
    Pro
}