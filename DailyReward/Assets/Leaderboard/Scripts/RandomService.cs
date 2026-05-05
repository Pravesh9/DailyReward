using UnityEngine;

public class RandomService : IRandomService
{
    public int Range(int min, int max)
    {
        return Random.Range(min, max);
    }
}