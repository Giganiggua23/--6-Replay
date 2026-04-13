using UnityEngine;

public class PlayerInputRecorder : MonoBehaviour
{
    public PlayerMovement player;

    void Update()
    {
       
       
        if (ReplayPlayer.Instance.IsPlaying) return;

        
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (move != Vector2.zero)
        {
            ReplayRecorder.Instance.Record(new Command
            {
                type = CommandType.Move,
                moveDir = move
            });
        }
        player.ApplyMove(move);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReplayRecorder.Instance.Record(new Command
            {
                type = CommandType.Action,
                actionId = 1
            });

        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ReplayRecorder.Instance.Record(new Command
            {
                type = CommandType.Select,
                selectId = 1
            });
        }
    }
}