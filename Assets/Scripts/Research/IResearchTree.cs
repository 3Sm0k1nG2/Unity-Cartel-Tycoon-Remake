using System.Collections.Generic;

public interface IResearchTree
{
    IDictionary<byte, string> Descriptions { get; }
    IDictionary<byte, IResearch> Researches { get; }
    public bool IsMilitarySupportAided { get; }

}