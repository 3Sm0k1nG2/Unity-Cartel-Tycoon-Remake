using System.Collections;

public class FarmOffState : FarmState
{ 
    public FarmOffState(Farm farm) : base(farm)
    {

    }

    public override IEnumerator Start()
    {
        Farm.IsOn = false;

        yield break;
    }

    public override IEnumerator TurnOn()
    {
        Farm.SetState(new FarmOnState(Farm));

        yield break;
    }
}