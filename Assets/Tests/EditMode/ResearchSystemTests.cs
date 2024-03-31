using NUnit.Framework;

public class ResearchSystemTests
{
    [Test]
    public void InitialState()
    {
        var RS = new ResearchSystem();
        
        Assert.AreEqual(ResearchState.Researched,   RS.Researches.TierI.State);
        Assert.AreEqual(ResearchState.Researchable, RS.Researches.FarmI.State);
        Assert.AreEqual(ResearchState.Unavailable,  RS.Researches.CropYieldI.State);
        Assert.AreEqual(ResearchState.Locked,       RS.Researches.FarmIPowerI.State);
        Assert.AreEqual(ResearchState.Researched,   RS.Researches.RoadSandy.State);
    }

    [Test]
    public void Research_ResearchedFarmI()
    {
        var RS = new ResearchSystem();

        RS.Research(RS.Researches.FarmI);
        Assert.AreEqual(ResearchState.Researched, RS.Researches.FarmI.State);
    }

    [Test]
    public void Research_ResearchedFarmI_Should_UnlockCropYieldI()
    {
        var RS = new ResearchSystem();

        RS.Research(RS.Researches.FarmI);
        Assert.AreEqual(ResearchState.Researchable, RS.Researches.CropYieldI.State);
    }

    [Test]
    public void Research_ResearchedFarmIWithoutMilitaryAid_Should_StillLockedPowerI()
    {
        var RS = new ResearchSystem();

        RS.Research(RS.Researches.FarmI);
        Assert.AreEqual(ResearchState.Locked, RS.Researches.FarmIPowerI.State);
    }

    [Test]
    public void Research_ResearchedFarmIWithMilitaryAid_Should_UnlockPowerI()
    {
        var game = new Game();
        var RS = game.RS;

        game.Military.ActiveResearchSupport();
        RS.Research(RS.Researches.FarmI);
        Assert.AreEqual(ResearchState.Researchable, RS.Researches.FarmIPowerI.State);
    }

    [Test]
    public void Research_ResearchedFarmIWithMilitaryAid_Should_UnlockFarmIPowerI_Then_RemovingMilitaryAid_Should_LockFarmIPowerIAgain()
    {
        var game = new Game();
        var RS = game.RS;

        game.Military.ActiveResearchSupport();
        RS.Research(RS.Researches.FarmI);
        game.Military.DeactiveResearchSupport();
        Assert.AreEqual(ResearchState.Locked, RS.Researches.FarmIPowerI.State);
    }

    [Test]
    public void Research_PrerequisiteResearched_WithMilitarySupport_UnavailablePowerI()
    {
        var game = new Game();
        var RS = game.RS;

        game.Military.ActiveResearchSupport();
        Assert.AreEqual(ResearchState.Unavailable, RS.Researches.FarmIPowerI.State);
    }

    [Test]
    public void Research_ResearchedPowerI_Then_RemovingMilitaryAid_Should_LockPowerI_And_AddingMilitaryAidAgain_Should_RestoreStateToResearched()
    {
        var game = new Game();
        var RS = game.RS;

        game.Military.ActiveResearchSupport();

        RS.Research(RS.Researches.FarmI);
        RS.Research(RS.Researches.FarmIPowerI);

        game.Military.DeactiveResearchSupport();
        Assert.AreEqual(ResearchState.Locked, RS.Researches.FarmIPowerI.State);

        game.Military.ActiveResearchSupport();
        Assert.AreEqual(ResearchState.Researched, RS.Researches.FarmIPowerI.State);
    }
}
