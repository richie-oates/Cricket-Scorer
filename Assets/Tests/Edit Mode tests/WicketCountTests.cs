using NUnit.Framework;

public class WicketCountTests
{
    [Test]
    public void WicketCountTest()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, new Wicket(WicketTypeEnum.BOWLED)));

        Assert.AreEqual(1, innings.Wickets);
    }

    [Test]
    public void MultipleWicketsCountTest()
    {
        Innings scorer = new Innings();

        scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, new Wicket(WicketTypeEnum.BOWLED)));
        scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, new Wicket(WicketTypeEnum.BOWLED)));
        for (int i = 0; i < 6; i++)
        {
            scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 1));
        }
        scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, new Wicket(WicketTypeEnum.BOWLED)));

        Assert.AreEqual(3, scorer.Wickets);
    }
}
