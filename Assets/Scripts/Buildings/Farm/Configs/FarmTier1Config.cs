public class FarmTierOneConfig
{
    public short DirtyCost { get; }
    public short LegalCost { get; }

    public byte DirtyBuildingUpkeep { get; }
    public byte LegalBuildingUpkeep { get; }
    
    public ProductProductionInfo[] Products { get;} 

    public FarmTierOneConfig()
    {
        LegalCost = DirtyCost = 500;
        LegalBuildingUpkeep = DirtyBuildingUpkeep = 5;

        Products = new ProductProductionInfo[]
        {
            //new ProductProductionInfo { Product = new Coffee(), }
        };
    }
}

public class ProductProductionInfo
{
    public IProduct Product { get; }
    public byte ProductionQuantity { get; }
    public byte ProductionDuration { get; }
}