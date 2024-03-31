public class Game
{
    public ResearchSystem RS { get; }

    public Military Military { get; }

    public Game()
    {
        RS = new ResearchSystem();
        Military = new Military(this);
    }

}