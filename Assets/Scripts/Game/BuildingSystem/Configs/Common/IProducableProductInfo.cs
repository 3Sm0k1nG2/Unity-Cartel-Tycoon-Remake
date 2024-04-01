public interface IProducableProductInfo
{
    IProduct Product { get; }
    GameTimeDuration ProductionDuration { get; }
    byte ProductionQuantity { get; }
}