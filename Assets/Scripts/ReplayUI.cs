using UnityEngine;

public class ReplayUI : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            ReplayRecorder.Instance.StartRecording();

        if (Input.GetKeyDown(KeyCode.F2))
            ReplayRecorder.Instance.StopRecording();

        if (Input.GetKeyDown(KeyCode.F3))
            ReplayPlayer.Instance.PlayLast();
    }
}