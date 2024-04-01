public class Game
{
    public ResearchSystem RS { get; }
    public BuildingSystem BS { get; }

    public Military Military { get; }

    public Game()
    {
        BS = new BuildingSystem();
        RS = new ResearchSystem(this);
        Military = new Military(this);

        //RS.OnResearchResearched += OnResearchResearched;
    }

    private void OnResearchResearched(IResearch researched)
    {
        // TODO FIND ME - Research system should tell the game to update the building config via the BuildingConfigCreator (creates new config with the new upgrades and replaces the old one)
    }
}

public class BuildingSystem
{
    public BuildingConfigs Configs { get; }

    public BuildingSystem()
    {
        Configs = new BuildingConfigs();
    }
}

public class BuildingConfigs
{
    public FarmIConfig FarmIConfig { get; set; }

    public BuildingConfigs()
    {
        FarmIConfig = new FarmIConfig();
    }
}
