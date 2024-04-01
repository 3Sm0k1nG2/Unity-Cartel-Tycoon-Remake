using System.Collections;

public abstract class FarmState : IFarmState
{
    protected Farm Farm;

    public FarmState(Farm farm)
    {
        Farm = farm;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Update()
    {
        yield break;
    }

    public virtual IEnumerator TurnOn()
    {
        yield break;
    }
    public virtual IEnumerator TurnOff()
    {
        yield break;
    }

    public virtual IEnumerator ChangeProduct(IProduct product)
    {
        yield break;
    }
}