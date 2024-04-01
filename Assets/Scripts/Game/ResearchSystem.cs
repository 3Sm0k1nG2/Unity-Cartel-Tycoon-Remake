using System.Collections.Generic;

public class ResearchSystem
{
    private Game _game;

    private Dictionary<IResearch, IResearch[]> ResearchUnlocks { get; }
    public IMilitaryAssistedResearch[] MilitaryAssistedResearches { get; }

    public Researches Researches { get; }

    public IResearch? CurrentResearchTarget { get; private set; }
    public byte ResearchProgress { get; }
    public IList<IResearch> ResearchQueue { get; }

    public ResearchSystem(Game game)
    {
        _game = game;

        Researches = new Researches(_game);

        ResearchUnlocks = new Dictionary<IResearch, IResearch[]>()
        {
            { Researches.TierI, new IResearch[] { Researches.FarmI, Researches.RoadSandy } },
            { Researches.FarmI, new IResearch[] { Researches.CropYieldI, Researches.FarmIPowerI } },
        };

        MilitaryAssistedResearches = new IMilitaryAssistedResearch[]
        {
            Researches.FarmIPowerI
        };

        ResearchQueue = new List<IResearch>();
    }


    private void UnlockNextResearches()
    {
        if (!ResearchUnlocks.ContainsKey(CurrentResearchTarget)) return;

        foreach (var researchable in ResearchUnlocks[CurrentResearchTarget])
        {
            researchable.ChangeState(ResearchState.Researchable);
        }
    }

    private void LockAndDequeNextResearches()
    {
        foreach (var researchable in ResearchUnlocks[CurrentResearchTarget])
        {
            if (ResearchQueue.Contains(researchable))
            {
                ResearchQueue.Remove(researchable);
            }

            researchable.ChangeState(ResearchState.Unavailable);
        }
    }

    private void OnResearching()
    {

    }

    private void OnResearched()
    {
        CurrentResearchTarget.ChangeState(ResearchState.Researched);

        foreach( var config in CurrentResearchTarget.AffectedBuildingConfigs)
        {
            config.UnlockUpgrade(_game, CurrentResearchTarget);
        }

        CurrentResearchTarget = null;
        BeginNextResearch();
    }

    private void BeginNextResearch()
    {
        if (ResearchQueue.Count == 0) return;

        CurrentResearchTarget = ResearchQueue[0];
        ResearchQueue.RemoveAt(0);

        BeginResearch();
    }


    public void Research(IResearch researchable)
    {
        if (researchable == null || researchable.State != ResearchState.Researchable) return;

        if (CurrentResearchTarget == null)
        {
            CurrentResearchTarget = researchable;
            BeginResearch();
            return;
        }

        ResearchQueue.Add(researchable);
    }

    private void BeginResearch()
    {
        CurrentResearchTarget.ChangeState(ResearchState.Researching);

        UnlockNextResearches();

        OnResearching();
        OnResearched();
    }

    public void CancelResearch()
    {
        CurrentResearchTarget.ChangeState(ResearchState.Researchable);

        LockAndDequeNextResearches();
        BeginNextResearch();
    }
}