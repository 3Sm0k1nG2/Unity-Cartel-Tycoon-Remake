using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FarmTests
{
    [Test]
    public void InitialState()
    {
        var farm = new Farm();

        Assert.AreEqual(null, farm.Product);
        Assert.AreEqual(0, farm.ProductProducedQuantity);
        Assert.IsFalse(farm.IsOn);
    }
}
