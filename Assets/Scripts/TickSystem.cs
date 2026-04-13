using UnityEngine;

public class TickSystem : MonoBehaviour
{
    public static TickSystem Instance;

    public int TickRate = 50;
    public int CurrentTick { get; private set; }

    private float tickTimer;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        CurrentTick++;
    }

    public void ResetTicks()
    {
        CurrentTick = 0;
    }
}