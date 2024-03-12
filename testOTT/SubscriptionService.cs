using System.Collections.Generic;

interface ISubscriptionService
{
    List<Subscription> GetAvailableSubscriptions();
}

class SubscriptionService : ISubscriptionService
{
    public List<Subscription> GetAvailableSubscriptions()
    {
        // Mock data for available subscriptions
        return new List<Subscription>
        {
            new Subscription { Name = "GOLD", Cost = 9.99, Perks = "HD Streaming, Unlimited Shows", DurationInMonths = 1 },
            new Subscription { Name = "DIAMOND", Cost = 14.99, Perks = "Ultra HD Streaming, Exclusive Shows", DurationInMonths = 3 },
            new Subscription { Name = "PLATINUM", Cost = 19.99, Perks = "4K Streaming, Early Access to New Releases", DurationInMonths = 6 },
        };
    }
}
