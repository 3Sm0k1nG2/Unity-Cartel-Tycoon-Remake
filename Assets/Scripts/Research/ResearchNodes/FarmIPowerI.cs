using System;

public class FarmIPowerI : IMilitaryAssistedResearch, IResearch
{
    private ResearchState prevState;

    public string Name { get; }
    public string Description { get; }

    public bool IsMilitarySupportRequired { get; }

    public short Cost { get; }
    public GameTimeDuration Duration { get; }
    public ResearchState State { get; private set; }


    public object[] Specifications { get; }

    public FarmIPowerI(IResearchTree RT)
    {
        prevState = ResearchState.Unavailable;

        Name = "Power I";
        Description = RT.Descriptions[0x3];

        IsMilitarySupportRequired = true;

        Cost = 500;
        Duration = new GameTimeDuration(0, 0, 2);
        State = RT.IsMilitarySupportAided ? ResearchState.Unavailable : ResearchState.Locked;

        Specifications = new object[]
        {
            "Affects Farm I",
            "Building power 1 > 3",
        };
    }

    public void EnforceLockedState()
    {
        prevState = State;
        State = ResearchState.Locked;
    }

    public void RestoreState()
    {
        State = prevState;
        prevState = ResearchState.None;
    }

    public void ChangeState(ResearchState state)
    {
        if (State + 1 != state) return;

        State = state;
    }
}
