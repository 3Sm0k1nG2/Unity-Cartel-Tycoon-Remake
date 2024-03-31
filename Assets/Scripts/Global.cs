public class Global
{
    public static Global Instance { get; } = new Global();

    public ResearchDescriptions ResearchDescriptions { get; }

    private Global()
    {
        ResearchDescriptions = new ResearchDescriptions();
    }
}
