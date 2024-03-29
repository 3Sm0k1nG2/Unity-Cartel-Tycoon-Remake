public class TierI : IResearch
{
    public string Name { get; }
    public string Description { get; }

    public short Cost { get; }
    public GameTimeDuration Duration { get; }
    public ResearchState State { get; private set; }

    public object[] Specifications { get; }

    public TierI(IResearchTree RT)
    {
        Name = "Tier I";
        Description = RT.Descriptions[0x0];
        
        Cost = 0;
        Duration = new GameTimeDuration();
        State = ResearchState.Researched;

        Specifications = new object[0];
    }

    public void ChangeState(ResearchState state)
    {
        if (State + 1 != state) return;

        State = state;
    }
}
