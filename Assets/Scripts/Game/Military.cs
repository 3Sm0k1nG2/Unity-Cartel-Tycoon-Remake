using System;

public class Military
{
    private Game _game;

    public bool IsResearchSupportActive { get; private set; }
    public bool IsPowerGainOnBuildingVisitActive { get; private set; }
    public bool IsNationalArmyBlindEyeActive { get; private set; }

    public Military(Game game)
    {
        _game = game;
    }

    public void ActiveResearchSupport()
    {
        IsResearchSupportActive = true;

        foreach (var research in _game.RS.MilitaryAssistedResearches)
        {
            research.RestoreState();
        }
    }

    public void DeactiveResearchSupport()
    {
        IsResearchSupportActive = false;

        foreach (var research in _game.RS.MilitaryAssistedResearches)
        {
            research.EnforceLockedState();
        }
    }

    public void ActivatePowerGainOnBuildingVisit()
    {
        throw new NotImplementedException();
    }

    public void DeactivatePowerGainOnBuildingVisit()
    {
        throw new NotImplementedException();
    }

    public void ActivateNationalArmyBlindEye()
    {
        throw new NotImplementedException();
    }

    public void DeactivateNationalArmyBlindEye()
    {
        throw new NotImplementedException();
    }
}