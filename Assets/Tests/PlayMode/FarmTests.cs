using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FarmTests
{
    [UnityTest]
    public IEnumerator TurnOn_ShouldTurnOnFarm()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        farm.TurnOn();
        Assert.IsTrue(farm.IsOn);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TurnOff_ShouldTurnOffFarm()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        farm.TurnOff();
        Assert.IsFalse(farm.IsOn);

        yield return null;
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Update_ShouldNotProduceWithoutSelectedProductType()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        farm.TurnOn();

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(farm.ProductionDuration);
        Assert.AreEqual(0, farm.ProductProducedQuantity);
    }

    [UnityTest]
    public IEnumerator Update_ShouldProduceSingleTime()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        farm.TurnOn();

        farm.ChangeProduct(new Opium());
        yield return new WaitForSeconds(farm.ProductionDuration);
        Assert.AreEqual(farm.ProductionQuantity, farm.ProductProducedQuantity);
    }

    [UnityTest]
    public IEnumerator Update_ShouldProduceSingleTimeWithPauseInBetween()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        farm.TurnOn();

        farm.ChangeProduct(new Opium());
        yield return new WaitForSeconds(farm.ProductionDuration/2);
        Assert.AreEqual(0, farm.ProductProducedQuantity);
        
        farm.TurnOff();
        yield return new WaitForSeconds(farm.ProductionDuration / 2);
        Assert.AreEqual(0, farm.ProductProducedQuantity);
        
        farm.TurnOn();
        yield return new WaitForSeconds(farm.ProductionDuration / 2);
        Assert.AreEqual(farm.ProductionQuantity, farm.ProductProducedQuantity);
    }

    [UnityTest]
    public IEnumerator ChangeProduct_ProductShouldBeChangedImmediatly()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        var opium = new Opium();

        farm.TurnOn();
        
        farm.ChangeProduct(opium);
        yield return new WaitForFixedUpdate();
        Assert.AreEqual(opium, farm.Product);
    }

    [UnityTest]
    public IEnumerator ChangeProduct_ProductShouldNotChangeBeforeCurrentIsProduced()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        farm.TurnOn();

        var opium = new Opium();

        farm.ChangeProduct(opium);
        yield return new WaitForFixedUpdate();
        Assert.AreEqual(opium, farm.Product);

        var coffee = new Coffee();

        farm.ChangeProduct(coffee);
        yield return new WaitForFixedUpdate();
        Assert.AreEqual(opium, farm.Product);
    }

    [UnityTest]
    public IEnumerator ChangeProduct_ProductShouldChangeAfterPreviousIsProduced()
    {
        var gameObject = new GameObject();
        var farm = gameObject.AddComponent<Farm>();

        farm.TurnOn();
        
        var opium = new Opium();
        
        farm.ChangeProduct(opium);
        yield return new WaitForFixedUpdate();
        Assert.AreEqual(opium, farm.Product);

        var coffee = new Coffee();

        farm.ChangeProduct(coffee);
        yield return new WaitForSeconds(farm.ProductionDuration);
        Assert.AreEqual(coffee, farm.Product);
    }


}
