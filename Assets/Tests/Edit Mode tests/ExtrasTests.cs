using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ExtrasTests
{
    [Test]
    public void NoballNoRuns()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.NO_BALL, 0));

        Assert.AreEqual(1, innings.Score);
        Assert.AreEqual(0, innings.Overs);
    }

    [Test]
    public void NoballWithRuns()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.NO_BALL, 6));

        Assert.AreEqual(7, innings.Score);
        Assert.AreEqual(0, innings.Overs);
    }

    [Test]
    public void WideNoRuns()
    {
        Innings innings = new Innings();
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.WIDE, 0));

        Assert.AreEqual(1, innings.Score);
        Assert.AreEqual(0, innings.Overs);
        Assert.AreEqual(1, innings.Wides);
    }

    [Test]
    public void WideWithRuns()
    {
        Innings innings = new Innings();
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.WIDE, 6));

        Assert.AreEqual(7, innings.Score);
        Assert.AreEqual(0, innings.Overs);
        Assert.AreEqual(7, innings.Wides);
    }

    [Test]
    public void LegByes()
    {
        Innings innings = new Innings();
        innings.AddDelivery(new Delivery(Delivery.RunsTypeEnum.LEG_BYE, 1));

        Assert.AreEqual(1, innings.Score);
        Assert.AreEqual(0.1f, innings.Overs);
    }

    [Test]
    public void SevenBallOver()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.NO_BALL, 0));
        for (int i = 0; i < 6; i++)
        {
            innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 1));
        }

        Assert.AreEqual(7, innings.Score);
        Assert.AreEqual(1f, innings.Overs);
    }

    [Test]
    public void TestErraticOver()
    {
        Innings innings = new Innings();

        ErraticOver(innings);

        Assert.AreEqual(14, innings.Score);
        Assert.AreEqual(1f, innings.Overs);
    }

    void ErraticOver(Innings innings)
    {
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.NO_BALL, 0));
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.WIDE, 1));
        innings.AddDelivery(new Delivery(Delivery.RunsTypeEnum.BYE, 1));
        innings.AddDelivery(new Delivery(Delivery.RunsTypeEnum.LEG_BYE, 1));
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 0));
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));
        innings.AddDelivery(new Delivery(new Wicket(WicketTypeEnum.BOWLED)));
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.NO_BALL, 2));
        innings.AddDelivery(new Delivery(new Wicket(WicketTypeEnum.CAUGHT)));
    }

    [Test]
    public void NoballPlusByes()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.NO_BALL, Delivery.RunsTypeEnum.BYE, 2));

        Assert.AreEqual(3, innings.Score);
        Assert.AreEqual(0.0f, innings.Overs);
        Assert.AreEqual(0, innings.Byes);
        Assert.AreEqual(3, innings.NoBalls);
    }

    [Test]
    public void ByeCount()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.RunsTypeEnum.BYE, 2));

        Assert.AreEqual(2, innings.Byes);
    }

    [Test]
    public void LegByeCount()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.RunsTypeEnum.LEG_BYE, 2));

        Assert.AreEqual(2, innings.LegByes);
    }

    [Test]
    public void WidePlusWicket()
    {
        Innings innings = new Innings();
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.WIDE, new Wicket(WicketTypeEnum.STUMPED)));

        Assert.AreEqual(1, innings.Score);
        Assert.AreEqual(1, innings.Wickets);
    }
}
