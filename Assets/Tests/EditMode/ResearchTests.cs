using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ResearchTests
{
    [Test]
    public void InitialState()
    {
        var RT = new ResearchTree();

        Assert.AreEqual(ResearchState.Researched, RT.Researches[0x0].State);
        Assert.AreEqual(ResearchState.Researchable, RT.Researches[0x1].State);
        Assert.AreEqual(ResearchState.Unavailable, RT.Researches[0x2].State);
        Assert.AreEqual(ResearchState.Locked, RT.Researches[0x3].State);
        Assert.AreEqual(ResearchState.Researched, RT.Researches[0x4].State);
    }

    [Test]
    public void Research_ResearchedFarmI()
    {
        var RT = new ResearchTree();

        RT.Research(0x1);
        RT.Research(0x1);
        Assert.AreEqual(ResearchState.Researched, RT.Researches[0x1].State);
    }

    [Test]
    public void Research_ResearchedFarmI_Should_UnlockCropYieldI()
    {
        var RT = new ResearchTree();

        RT.Research(0x1);
        Assert.AreEqual(ResearchState.Researchable, RT.Researches[0x2].State);
    }

    [Test]
    public void Research_ResearchedFarmIWithoutMilitaryAid_Should_StillLockedPowerI()
    {
        var RT = new ResearchTree();

        RT.Research(0x1);
        Assert.AreEqual(ResearchState.Locked, RT.Researches[0x3].State);
    }

    [Test]
    public void Research_ResearchedFarmIWithMilitaryAid_Should_UnlockPowerI()
    {
        var RT = new ResearchTree();

        RT.AddMilitarySupport();

        RT.Research(0x1);
        Assert.AreEqual(ResearchState.Researchable, RT.Researches[0x3].State);
    }

    [Test]
    public void Research_ResearchedFarmIWithMilitaryAid_Should_UnlockPowerI_Then_RemovingMilitaryAid_Should_LockPowerIAgain()
    {
        var RT = new ResearchTree();

        RT.AddMilitarySupport();

        RT.Research(0x1);
        RT.RemoveMilitarySupport();
        Assert.AreEqual(ResearchState.Locked, RT.Researches[0x3].State);
    }

    [Test]
    public void Research_PrerequisiteResearched_WithoutMilitarySupport_LockedPowerI()
    {
        var RT = new ResearchTree();

        RT.Research(0x1);
        Assert.AreEqual(ResearchState.Locked, RT.Researches[0x3].State);
    }

    [Test]
    public void Research_PrerequisiteResearched_WithMilitarySupport_UnavailablePowerI()
    {
        var RT = new ResearchTree();

        RT.AddMilitarySupport();
        Assert.AreEqual(ResearchState.Unavailable, RT.Researches[0x3].State);
    }

    [Test]
    public void Research_ResearchedPowerI_Then_RemovingMilitaryAid_Should_LockPowerI_And_AddingMilitaryAidAgain_Should_RestoreStateToResearched()
    {
        var RT = new ResearchTree();

        RT.AddMilitarySupport();

        RT.Research(0x1);
        RT.Research(0x3);
        
        RT.RemoveMilitarySupport();
        Assert.AreEqual(ResearchState.Locked, RT.Researches[0x3].State);
        
        RT.AddMilitarySupport();
        Assert.AreEqual(ResearchState.Researched, RT.Researches[0x3].State);
    }
}
