using System.Collections.Generic;

public class Over
{
    List<Delivery> deliveries;
    
    public Over() 
    {
        deliveries = new List<Delivery>();
    }

    #region Properties
    public int Score => CalculateScoreForOver();
    public int LegitimateDeliveries => SumLegitimateDeliveries();
    public int Wickets => CountWickets();
    public int NoBallDeliveries => SumDeliveriesOfType(Delivery.DeliveryTypeEnum.NO_BALL);
    public int WideDeliveries => SumDeliveriesOfType(Delivery.DeliveryTypeEnum.WIDE);
    public int RunsFromByes => SumRunsOfType(Delivery.RunsTypeEnum.BYE);
    public int RunsFromLegByes => SumRunsOfType(Delivery.RunsTypeEnum.LEG_BYE);
    #endregion

    #region Methods
    public void AddDelivery(Delivery delivery)
    {
        deliveries.Add(delivery);
    }

    public int SumRunsOfType(Delivery.RunsTypeEnum runsType)
    {
        int count = 0;
        foreach (Delivery delivery in deliveries)
        {
            if (delivery.RunsType != runsType) continue;
            if (runsType != Delivery.RunsTypeEnum.BAT)
            {
                if (delivery.DeliveryType == Delivery.DeliveryTypeEnum.NO_BALL
                   || delivery.DeliveryType == Delivery.DeliveryTypeEnum.WIDE)
                {
                    continue;
                }
            }
            count += delivery.Runs;
        }
        return count;
    }

    public int SumRunsOfType(Delivery.DeliveryTypeEnum deliveryType)
    {
        int count = 0;
        foreach (Delivery delivery in deliveries)
        {
            if (delivery.DeliveryType != deliveryType) continue;
            if (deliveryType != Delivery.DeliveryTypeEnum.GOOD)
            {
                count++;
            }
            count += delivery.Runs;
        }
        return count;
    }

    public int SumDeliveriesOfType(Delivery.DeliveryTypeEnum type)
    {
        int count = 0;
        foreach (Delivery delivery in deliveries)
        {
            if (delivery.DeliveryType == type)
            {
                count++;
            }
        }
        return count;
    }

    int CalculateScoreForOver()
    {
        int score = 0;
        foreach (Delivery delivery in deliveries)
        {
            score += delivery.Runs;

            if (delivery.DeliveryType == Delivery.DeliveryTypeEnum.NO_BALL
                || delivery.DeliveryType == Delivery.DeliveryTypeEnum.WIDE)
            {
                score++;
            }
        }
        return score;
    }

    int SumLegitimateDeliveries()
    {
        // A delivery is legitimate if the umpire has not signaled it a NoBall or Wide
        int count = 0;
        foreach (Delivery delivery in deliveries)
        {
            if (delivery.DeliveryType != Delivery.DeliveryTypeEnum.NO_BALL && delivery.DeliveryType != Delivery.DeliveryTypeEnum.WIDE)
            {
                count++;
            }
        }
        return count;
    }

    int CountWickets()
    {
        int count = 0;
        foreach (Delivery delivery in deliveries)
        {
            if (delivery.Wicket != null)
            {
                count++;
            }
        }
        return count;
    }

    #endregion
}