public class CropYieldI : IResearch
{
    public string Name { get; }
    public string Description { get; }

    public short Cost { get; }
    public GameTimeDuration Duration { get; }
    public ResearchState State { get; private set; }

    public IBuildingConfig[] AffectedBuildingConfigs { get; }
    public object[] Specifications { get; }

    public CropYieldI(Game game)
    {
        Name = "Crop Yield I";
        Description = Global.Instance.ResearchDescriptions.PASSIVE_INCREASE_PRODUCT_VOLUME;

        Cost = 1000;
        Duration = new GameTimeDuration(0, 1);
        State = ResearchState.Unavailable;

        AffectedBuildingConfigs = new IBuildingConfig[] { game.BS.Configs.FarmIConfig };

        Specifications = new object[]
        {
            "Affects Farm I",
            "Opium: Output 2 > 3",
            "Vegatables: Output 14 > 15",
            "Coffee: Output 6 > 7",
        };
    }

    public void ChangeState(ResearchState state)
    {
        if (State + 1 != state) return;

        State = state;
    }
}
