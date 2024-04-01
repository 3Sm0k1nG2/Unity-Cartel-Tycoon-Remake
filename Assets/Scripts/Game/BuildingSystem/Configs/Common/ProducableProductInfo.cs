public class ProducableProductInfo : IProducableProductInfo
{
    public IProduct Product { get; }
    public byte ProductionQuantity { get; }
    public GameTimeDuration ProductionDuration { get; }

    public ProducableProductInfo(
        IProduct product,
        byte productionQuantity,
        GameTimeDuration productionDuration
    )
    {
        Product = product;
        ProductionQuantity = productionQuantity;
        ProductionDuration = productionDuration;
    }
}