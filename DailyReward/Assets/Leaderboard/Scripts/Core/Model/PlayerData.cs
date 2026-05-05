using System;
namespace System.Leaderboard
{
    [Serializable]
    public class PlayerData
    {
        public string PlayerName;
        public int Score;

        public PlayerData(string name, int score)
        {
            PlayerName = name;
            Score = score;
        }
    }
}