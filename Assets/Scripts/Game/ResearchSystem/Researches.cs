public class Researches
{
    private Game _game;

    public TierI TierI { get; }
    public FarmI FarmI { get; }
    public CropYieldI CropYieldI { get; }
    public FarmIPowerI FarmIPowerI { get; }
    public RoadSandy RoadSandy { get; }

    public Researches(Game game)
    {
        _game = game;

        TierI = new TierI(game);
        FarmI = new FarmI(game);
        CropYieldI = new CropYieldI(game);
        FarmIPowerI = new FarmIPowerI(game);
        RoadSandy = new RoadSandy(game);
    }
}