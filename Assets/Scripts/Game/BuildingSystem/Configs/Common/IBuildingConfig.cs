public interface IBuildingConfig
{
    public short DirtyCost { get; }
    public short LegalCost { get; }

    public byte DirtyUpkeep { get; }
    public byte LegalUpkeep { get; }

    public byte Power { get;}
    public byte StorageCapacity { get; }
    public byte LoyaltyIncreaseOnBuildup { get; }

    public void UnlockUpgrade(Game game, IResearch researched);
}