using System.Collections.Generic;

public class ResearchTree : IResearchTree
{
    public IDictionary<byte, IResearch> Researches { get; }

    public IDictionary<byte, string> Descriptions { get; }

    public IDictionary<byte, byte[]> ResearchPrerequisiteIDs { get; }
    public IDictionary<byte, byte[]> ResearchUnlockIDs { get; }
    public byte[] MilitaryAssistedResearchIDs { get; }

    public bool IsMilitarySupportAided { get; private set; } 

    public IResearch? CurrentResearchTarget { get; private set; }

    public ResearchTree()
    {
        IsMilitarySupportAided = false;

        Descriptions = new Dictionary<byte, string>()
        {
            { 0x0, "Unlocks the ability to research higher-level upgrades and effects." },
            { 0x1, "[Upgrade] Unlocks Farm I" },
            { 0x2, "[Passive effect] Increase volume of the produced product." },
            { 0x3, "[Power I] Building power is increased." },
            { 0x4, "Poor quality roads: transport is moving and thanks for that." },
        };

        Researches = new Dictionary<byte, IResearch>()
        {
            { 0x0, new TierI(this) },
            { 0x1, new FarmI(this) },
            { 0x2, new CropYieldI(this) },
            { 0x3, new FarmIPowerI(this) },
            { 0x4, new RoadSandy(this) },
        };

        ResearchPrerequisiteIDs = new Dictionary<byte, byte[]>()
        {
            { 0x0, new byte[0] },
            { 0x1, new byte[] { 0x0 } },
            { 0x2, new byte[] { 0x1 } },
            { 0x3, new byte[] { 0x1 } },
            { 0x4, new byte[] { 0x0 } },
        };

        ResearchUnlockIDs = new Dictionary<byte, byte[]>()
        {
            { 0x0, new byte[] { 0x1, 0x4 } },
            { 0x1, new byte[] { 0x2, 0x3 } },
            { 0x2, new byte[] {  } },
            { 0x3, new byte[] {  } },
            { 0x4, new byte[] {  } },
        };

        MilitaryAssistedResearchIDs = new byte[]
        {
            0x3
        };
    }

    public void AddMilitarySupport()
    {
        IsMilitarySupportAided = true;

        foreach (var researchID in MilitaryAssistedResearchIDs)
        {
            ((IMilitaryAssistedResearch)Researches[researchID]).RestoreState();
        }
    }

    public void RemoveMilitarySupport()
    {
        IsMilitarySupportAided = false;

        foreach (var researchID in MilitaryAssistedResearchIDs)
        {
            ((IMilitaryAssistedResearch)Researches[researchID]).EnforceLockedState();
        }
    }

    public void Research(byte researchID)
    {
        if (CurrentResearchTarget is not null) return;

        CurrentResearchTarget = Researches[researchID];
        CurrentResearchTarget.ChangeState(ResearchState.Researching);

        foreach ( var unlockID in ResearchUnlockIDs[researchID])
        {
            Researches[unlockID].ChangeState(ResearchState.Researchable);
        }

        CurrentResearchTarget.ChangeState(ResearchState.Researched);
        CurrentResearchTarget = null;
    }
}