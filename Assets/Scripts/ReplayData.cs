using System.Collections.Generic;

[System.Serializable]
public class ReplayData
{
    public int seed;
    public int tickRate;

    public List<Command> commands = new List<Command>();
}