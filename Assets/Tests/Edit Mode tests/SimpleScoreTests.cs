using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SimpleScoreTests
{
    [Test]
    public void ScoreNormalRuns()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(6));

        Assert.AreEqual(6, innings.Score);
    }

    [Test]
    public void ScoreTwoDeliveries()
    {
        Innings innings = new Innings();

        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));
        innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 6));

        Assert.AreEqual(12, innings.Score);
    }

    [Test]
    public void ScoreTwentyOversOfSingles()
    {
        Innings innings = new Innings();

        for (int i = 0; i < 120; i++)
        {
            innings.AddDelivery(new Delivery(Delivery.DeliveryTypeEnum.GOOD, 1));
        }

        Assert.AreEqual(120, innings.Score);
    }
}
