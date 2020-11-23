namespace PaintBook.Content.WrireModel.Domain.Registration
{
    public class Subscription
    {
        public SubscriptionType SubscriptionType { get;private set; }
    }

    public  enum SubscriptionType
    {
        Free,
        Monthly,
        Annual

    }
}
