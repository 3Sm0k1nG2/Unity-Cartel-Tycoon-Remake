public struct GameTimeDuration
{
    public byte Years { get; }
    public byte Days { get; }
    public byte Hours { get; }
    public byte Minutes { get; }

    public GameTimeDuration(byte years = 0,  byte days = 0, byte hours = 0, byte minutes = 0)
    {
        Years = years;
        Days = days;
        Hours = hours;
        Minutes = minutes;
    }
}
