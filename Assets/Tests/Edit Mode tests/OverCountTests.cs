using NUnit.Framework;

public class OverCountTests
{
    [Test]
    public void OverCountOneDelivery()
    {
        Innings scorer = new Innings();

        scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));

        Assert.AreEqual(0.1f, scorer.Overs);
    }

    [Test]
    public void OverCountTwoDeliveries()
    {
        Innings scorer = new Innings();

        scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));
        scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));

        Assert.AreEqual(0.2f, scorer.Overs);
    }

    [Test]
    public void OverCountTenDeliveries()
    {
        Innings scorer = new Innings();

        for (int i = 0; i < 10; i++)
        {
            scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));
        }

        Assert.AreEqual(1.4f, scorer.Overs);
    }

    [Test]
    public void OverCountTwentyOvers()
    {
        Innings scorer = new Innings();

        for (int i = 0; i < 120; i++)
        {
            scorer.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));
        }

        Assert.AreEqual(20f, scorer.Overs);
    }
}
