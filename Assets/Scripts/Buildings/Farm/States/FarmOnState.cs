using System.Collections;

public class FarmOnState : FarmState
{ 
    public FarmOnState(Farm farm) : base(farm)
    {

    }

    private bool IsFarmProductionProductSelect()
    {
        return Farm.Product != null;
    }

    private void ChangeToProduceState()
    {
        if (Farm.ProduceState == null)
        {
            Farm.ProduceState = new FarmProduceState(Farm);
        }

        Farm.SetState(Farm.ProduceState);
    }

    public override IEnumerator Start()
    {
        Farm.IsOn = true;

        if (IsFarmProductionProductSelect()) ChangeToProduceState();
        
        
        yield break;
    }

    public override IEnumerator TurnOff()
    {
        Farm.SetState(new FarmOffState(Farm));

        yield break;
    }

    public override IEnumerator ChangeProduct(IProduct product)
    {
        Farm.Product = product;

        ChangeToProduceState();
        yield break;
    }
}