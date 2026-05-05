using UnityEngine;
namespace System.Leaderboard
{
    public class RandomService : IRandomService
    {
        public int Range(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
}