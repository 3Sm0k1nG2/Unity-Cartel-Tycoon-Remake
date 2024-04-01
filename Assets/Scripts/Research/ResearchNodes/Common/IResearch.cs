public interface IResearch
{
    public string Name { get; }
    public string Description { get; }

    public short Cost { get; }
    public GameTimeDuration Duration { get; }
    public ResearchState State { get; }

    public IBuildingConfig[] AffectedBuildingConfigs { get; }
    public object[] Specifications { get; }

    public void ChangeState(ResearchState state);
}