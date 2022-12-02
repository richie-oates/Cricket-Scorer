public class Delivery
{
    #region Fields
    int runs;
    RunsTypeEnum runsType;
    DeliveryTypeEnum deliveryType;
    Wicket wicket;
    #endregion

    #region Constructors
    public Delivery(DeliveryTypeEnum deliveryType, RunsTypeEnum runsType, int runs, Wicket wicket)
    {
        this.deliveryType = deliveryType;
        this.runsType = runsType;
        this.runs = runs;
        this.wicket = wicket;
    }

    public Delivery(DeliveryTypeEnum deliveryType, RunsTypeEnum runsType, int runs)
    {
        this.runs = runs;
        this.runsType = runsType;
        this.deliveryType = deliveryType;
    }

    public Delivery(DeliveryTypeEnum deliveryType, Wicket wicket)
    {
        this.deliveryType = deliveryType;
        this.wicket = wicket;
        runsType = RunsTypeEnum.NONE;
        runs = 0;
    }

    public Delivery(Wicket wicket)
    {
        this.deliveryType = DeliveryTypeEnum.GOOD;
        this.wicket = wicket;
        runsType = RunsTypeEnum.NONE;
        runs = 0;
    }

    public Delivery(DeliveryTypeEnum deliveryType, int runs)
    {
        this.runs = runs;
        this.runsType = RunsTypeEnum.BAT;
        this.deliveryType = deliveryType;
    }

    public Delivery(RunsTypeEnum runsType, int runs)
    {
        this.runs = runs;
        this.runsType = runsType;
        deliveryType = DeliveryTypeEnum.GOOD;
    }

    public Delivery(int runs)
    {
        this.runs = runs;
        deliveryType = DeliveryTypeEnum.GOOD;
    }
    #endregion

    #region Enums
    public enum DeliveryTypeEnum
    {
        GOOD,
        NO_BALL,
        WIDE
    }
    public enum RunsTypeEnum
    {
        BAT,
        BYE,
        LEG_BYE,
        NONE
    }
    #endregion

    #region Properties
    public int Runs => runs;
    public RunsTypeEnum RunsType => runsType;
    public DeliveryTypeEnum DeliveryType => deliveryType;
    public Wicket Wicket => wicket;
    #endregion
}