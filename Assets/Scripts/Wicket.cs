public class Wicket
{
    WicketTypeEnum wicketType;

    public Wicket(WicketTypeEnum wicketType)
    {
        this.wicketType = wicketType;
    }
}

public enum WicketTypeEnum
{
    BOWLED,
    CAUGHT,
    LBW,
    RUN_OUT,
    STUMPED,
    RETIRED,
    HIT_BALL_TWICE,
    HIT_WICKET,
    OBSTRUCTING_FIELD,
    TIMED_OUT
}