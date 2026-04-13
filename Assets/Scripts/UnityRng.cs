using UnityEngine;

public class UnityRng : IRng
{
    public void Init(int seed)
    {
        Random.InitState(seed);
    }

    public float Value()
    {
        return Random.value;
    }

    public int Range(int min, int max)
    {
        return Random.Range(min, max);
    }
}