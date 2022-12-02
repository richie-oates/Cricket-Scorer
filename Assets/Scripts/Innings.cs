using System;
using System.Collections.Generic;

public class Innings
{
    List<Over> completedOvers;
    Over currentOver;
    public Innings()
    {
        completedOvers = new List<Over>();
        currentOver = new Over();
    }

    #region Properties
    public int Score => CalculateCurrentScore();
    public int Wickets => GetWicketsLost();
    public float Overs => GetOversCount();
    public int Byes => GetTotalRunsOfType(Delivery.RunsTypeEnum.BYE);
    public int LegByes => GetTotalRunsOfType(Delivery.RunsTypeEnum.LEG_BYE);
    public int NoBalls => GetTotalRunsOfType(Delivery.DeliveryTypeEnum.NO_BALL);
    public int Wides => GetTotalRunsOfType(Delivery.DeliveryTypeEnum.WIDE);
    #endregion

    public void AddDelivery(Delivery delivery)
    {
        currentOver.AddDelivery(delivery);
        if (currentOver.LegitimateDeliveries >= 6)
        {
            completedOvers.Add(currentOver);
            currentOver = new Over();
        }
    }

    int GetWicketsLost()
    {
        int count = 0;
        foreach (Over over in completedOvers)
        {
            count += over.Wickets;
        }
        count += currentOver.Wickets;
        return count;
    }

    float GetOversCount()
    {
        return completedOvers.Count + (float) currentOver.LegitimateDeliveries / 10;
    }

    int CalculateCurrentScore()
    {
        int count = 0;
        foreach (Over over in completedOvers)
        {
            count += over.Score;
        }
        count += currentOver.Score;
        return count;
    }

    int GetTotalRunsOfType(Delivery.RunsTypeEnum runsType)
    {
        int count = 0;
        foreach (Over over in completedOvers)
        {
            count += over.SumRunsOfType(runsType);
        }
        count += currentOver.SumRunsOfType(runsType);
        return count;
    }

    int GetTotalRunsOfType(Delivery.DeliveryTypeEnum deliveryType)
    {
        int count = 0;
        foreach (Over over in completedOvers)
        {
            count += over.SumRunsOfType(deliveryType);
        }
        count += currentOver.SumRunsOfType(deliveryType);
        return count;
    }
}