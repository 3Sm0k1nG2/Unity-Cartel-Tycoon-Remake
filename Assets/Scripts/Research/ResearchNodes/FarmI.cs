public class FarmI : IResearch
{
    public string Name { get; }
    public string Description { get; }

    public short Cost { get; }
    public GameTimeDuration Duration { get; }
    public ResearchState State { get; private set; }

    public object[] Specifications { get; }

    public FarmI()
    {
        Name = "Farm I";
        Description = Global.Instance.ResearchDescriptions.UPGRADE_UNLOCK_FARM_I;
        
        Cost = 2000;
        Duration = new GameTimeDuration(0,2,2,24);
        State = ResearchState.Researchable;

        Specifications = new object[]
        {
            "Upkeep cost: Legal money $5",
            "Upkeep cost: Dirty money $5",
            "Building power 1",
            "Storage capacity XS",
            "Opium: Output 2",
            "Opium: Interval 13.6 hrs",
            "Vegatables: Output 14",
            "Vegatables: Interval 1 d",
            "Coffee: Output 6",
            "Coffee: Interval 1.7 d",
            "Loyalty one-time increase Tiny",
        };
    }

    public void ChangeState(ResearchState state)
    {
        if (State + 1 != state) return;

        State = state;
    }
}
