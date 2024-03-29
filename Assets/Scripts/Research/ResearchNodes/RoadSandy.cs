public class RoadSandy : IResearch
{
    public string Name { get; }
    public string Description { get; }

    public short Cost { get; }
    public GameTimeDuration Duration { get; }
    public ResearchState State { get; private set; }

    public object[] Specifications { get; }

    public RoadSandy(IResearchTree RT)
    {
        Name = "Road: Sandy";
        Description = RT.Descriptions[0x4];

        Cost = 0;
        Duration = new GameTimeDuration();
        State = ResearchState.Researched;

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