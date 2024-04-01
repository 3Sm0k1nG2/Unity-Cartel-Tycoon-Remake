public class Global
{
    public static Global Instance { get; } = new Global();

    public ResearchDescriptions ResearchDescriptions { get; }
    public Products Products { get; }
    public StorageCapacities StorageCapacities  { get;}
    public LoyaltyGains LoyaltyGains { get; }

    private Global()
    {
        ResearchDescriptions = new ResearchDescriptions();
        Products = new Products();
        StorageCapacities = new StorageCapacities();
        LoyaltyGains = new LoyaltyGains();
    }
}


public class Research
{
    public ResearchIds ResearchIds { get; }
    public ResearchDescriptions ResearchDescriptions { get; }
    public Research()
    {
        ResearchDescriptions = new ResearchDescriptions();
    }
}

public class ResearchIds
{
    public byte TIER_I = 0x0;
    public byte FARM_I = 0x1;
    public byte CROP_YIELD_I = 0x2;
    public byte FARM_I_POWER_I = 0x3;
    public byte ROAD_SANDY = 0x4;
}