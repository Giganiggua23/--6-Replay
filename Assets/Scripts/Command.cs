using UnityEngine;

public enum CommandType
{
    Move,
    Action,
    Select
}

[System.Serializable]
public class Command
{
    public int tick;
    public CommandType type;

    public Vector2 moveDir;
    public int actionId;
    public int selectId;
}