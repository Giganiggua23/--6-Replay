using UnityEngine;

public class ReplayRecorder : MonoBehaviour
{
    public static ReplayRecorder Instance;

    public ReplayData currentReplay;

    private void Awake()
    {
        Instance = this;
    }

    public void StartRecording()
    {
        currentReplay = new ReplayData();

        currentReplay.seed = Random.Range(0, 999999);
        currentReplay.tickRate = TickSystem.Instance.TickRate;

        TickSystem.Instance.ResetTicks();

    }

    public void StopRecording()
    {
        string json = JsonUtility.ToJson(currentReplay, true);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/replay.json", json);

    }

    public void Record(Command cmd)
    {
        cmd.tick = TickSystem.Instance.CurrentTick;
        currentReplay.commands.Add(cmd);
    }
}