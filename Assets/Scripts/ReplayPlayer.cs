using UnityEngine;
using System.Collections.Generic;

public class ReplayPlayer : MonoBehaviour
{
    public static ReplayPlayer Instance;

    public bool IsPlaying { get; private set; }

    private ReplayData replay;
    private int commandIndex;

    private IRng rng = new UnityRng();

    public PlayerMovement player;

    public Transform playerTransform;
    private Vector3 startPosition;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        startPosition = playerTransform.position;
    }

    public void PlayLast()
    {
        string path = Application.persistentDataPath + "/replay.json";

        if (!System.IO.File.Exists(path))
        {
            return;
        }

        string json = System.IO.File.ReadAllText(path);
        replay = JsonUtility.FromJson<ReplayData>(json);

        rng.Init(replay.seed);

        TickSystem.Instance.TickRate = replay.tickRate;
        TickSystem.Instance.ResetTicks();

        commandIndex = 0;
        IsPlaying = true;

        playerTransform.position = startPosition;




    }

    private void FixedUpdate()
    {
        if (!IsPlaying) return;

        int tick = TickSystem.Instance.CurrentTick;

        while (commandIndex < replay.commands.Count &&
               replay.commands[commandIndex].tick == tick)
        {
            Execute(replay.commands[commandIndex]);
            commandIndex++;
        }
    }

    void Execute(Command cmd)
    {
        switch (cmd.type)
        {
            case CommandType.Move:
                player.ApplyMove(cmd.moveDir);
                break;

            case CommandType.Action:
                Debug.Log("Replay Action");
                break;

            case CommandType.Select:
                Debug.Log("Replay Select");
                break;

        }
    }
}