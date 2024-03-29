using System.Collections;
using UnityEngine;

public class FarmProduceState : FarmState
{
    private float productionElapsedTime = .0f;

    private IProduct newProduct;

    public FarmProduceState(Farm farm) : base(farm)
    {

    }

    private bool IsProductChanged()
    {
        return newProduct != null;
    }

    private void ChangeProduct()
    {
        Farm.Product = newProduct;
        newProduct = null;
    }

    private void IncreaseProductionElapsedTime()
    {
        productionElapsedTime += Time.deltaTime;
    }

    private bool IsProductionTimeElapsed()
    {
        return productionElapsedTime >= Farm.ProductionDuration;
    }

    private void ProduceProduct()
    {
        IncreaseProductProducedQuantity();

        if (IsProductChanged())
        {
            ChangeProduct();
        }

        ResetProductionElapsedTime();
    }

    private void IncreaseProductProducedQuantity()
    {
        Farm.ProductProducedQuantity += Farm.ProductionQuantity;
    }

    private void ResetProductionElapsedTime()
    {
        productionElapsedTime = 0;
    }

    public override IEnumerator Update()
    {
        IncreaseProductionElapsedTime();

        if (IsProductionTimeElapsed())
        {
            ProduceProduct();
        }

        yield break;
    }

    public override IEnumerator TurnOff()
    {
        Farm.SetState(new FarmOffState(Farm));

        yield break;
    }

    public override IEnumerator ChangeProduct(IProduct product)
    {
        newProduct = product;

        yield break;
    }
}