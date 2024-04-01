public class FarmIConfig : IProducableBuildingConfig, IBuildingConfig
{
    public short LegalCost { get; }
    public short DirtyCost { get; }

    public byte LegalUpkeep { get; }
    public byte DirtyUpkeep { get; private set; }

    public byte Power { get; private set; }
    public byte StorageCapacity { get; private set; }
    public byte LoyaltyIncreaseOnBuildup { get; }

    public IProducableProductInfo[] ProducableProducts { get; private set; }

    public FarmIConfig()
    {
        LegalCost = DirtyCost = 500;

        LegalUpkeep = 5;
        DirtyUpkeep = 5;

        Power = 1;
        StorageCapacity = Global.Instance.StorageCapacities.XS;
        LoyaltyIncreaseOnBuildup = Global.Instance.LoyaltyGains.TINY;

        ProducableProducts = new IProducableProductInfo[]
        {
            new ProducableProductInfo(
                Global.Instance.Products.OPIUM,
                2,
                new GameTimeDuration(0,0,13,36)
            ),
            new ProducableProductInfo(
                Global.Instance.Products.VEGETABLES,
                14,
                new GameTimeDuration(0,1)
            ),
            new ProducableProductInfo(
                Global.Instance.Products.COFFEE,
                6,
                new GameTimeDuration(0,1,16,48)
            ),
        };
    }

    private void ActivateExtraYieldUpgrade()
    {
        ProducableProducts = new IProducableProductInfo[]
        {
            new ProducableProductInfo(
                Global.Instance.Products.OPIUM,
                3,
                new GameTimeDuration(0,0,13,36)
            ),
            new ProducableProductInfo(
                Global.Instance.Products.VEGETABLES,
                15,
                new GameTimeDuration(0,1)
            ),
            new ProducableProductInfo(
                Global.Instance.Products.COFFEE,
                7,
                new GameTimeDuration(0,1,16,48)
            ),
        };
    }

    private void ActivateExtraPowerUpgrade()
    {
        Power = 3;
    }

    private void ActivateExtraStorageUpgrade()
    {
        StorageCapacity = Global.Instance.StorageCapacities.S;
    }

    private void ActivateCheaperDirtyUpkeepUpgrade()
    {
        DirtyUpkeep = 3;
    }

    public void UnlockUpgrade(Game game, IResearch researched)
    {
        if (researched == game.RS.Researches.CropYieldI) ActivateExtraYieldUpgrade();
        else if (researched == game.RS.Researches.FarmIPowerI) ActivateExtraPowerUpgrade();
        else if (researched == game.RS.Researches.FarmIPowerI) ActivateExtraStorageUpgrade();
        else if (researched == game.RS.Researches.FarmIPowerI) ActivateCheaperDirtyUpkeepUpgrade();
    }
}

public class FarmIConfigUpgrades
{
    public bool IsExtraYieldActive { get; init; }
    public bool IsExtraStorageActive { get; init; }
    public bool IsCheaperDirtyUpkeepActive { get; init; }
    public bool IsExtraPowerActive { get; init; }
}