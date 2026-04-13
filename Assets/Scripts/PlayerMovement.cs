using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 currentMove;

    public void ApplyMove(Vector2 move)
    {
        currentMove = move;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(currentMove * speed * Time.fixedDeltaTime);


    }

    
}