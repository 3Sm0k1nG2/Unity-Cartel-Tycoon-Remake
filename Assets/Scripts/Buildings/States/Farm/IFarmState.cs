using System.Collections;

public interface IFarmState
{
    IEnumerator ChangeProduct(IProduct product);
    IEnumerator Start();
    IEnumerator TurnOff();
    IEnumerator TurnOn();
    IEnumerator Update();
}