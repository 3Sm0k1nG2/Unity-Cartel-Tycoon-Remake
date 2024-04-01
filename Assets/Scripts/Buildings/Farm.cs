using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public readonly float ProductionDuration = 2.0f;
    public readonly byte ProductionQuantity = 5;

    public bool IsOn = false;

    public IProduct Product = null;
    public byte ProductProducedQuantity = 0;

    private FarmState state;
    public FarmState ProduceState = null;

    public void SetState(FarmState state)
    {
        this.state = state;
        StartCoroutine(this.state.Start());
    }

    private void Awake()
    {
        SetState(new FarmOffState(this));
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(state.Update());
    }

    public void TurnOn()
    {
        StartCoroutine(state.TurnOn());
    }
    public void TurnOff()
    {
        StartCoroutine(state.TurnOff());
    }

    public void ChangeProduct(IProduct product)
    {
        StartCoroutine(state.ChangeProduct(product));
    }
}
