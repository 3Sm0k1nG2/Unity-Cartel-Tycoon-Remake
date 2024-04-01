public class RoadSandy : IResearch
{
    public string Name { get; }
    public string Description { get; }

    public short Cost { get; }
    public GameTimeDuration Duration { get; }
    public ResearchState State { get; private set; }

    public IBuildingConfig[] AffectedBuildingConfigs { get; }
    public object[] Specifications { get; }

    public RoadSandy(Game game)
    {
        Name = "Road: Sandy";
        Description = Global.Instance.ResearchDescriptions.ROAD_SANDY;

        Cost = 0;
        Duration = new GameTimeDuration();
        State = ResearchState.Researched;

        AffectedBuildingConfigs = new IBuildingConfig[0];
        Specifications = new object[]
        {
            "Construction cost Free",
            "Transport speed Slow",
        };
    }

    public void ChangeState(ResearchState state)
    {
        if (State + 1 != state) return;

        State = state;
    }
}
