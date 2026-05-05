using System.Collections.Generic;
namespace System.Leaderboard
{
    public interface ILeaderboardService
    {
        List<PlayerData> GetPlayers();
        void GeneratePlayers(int count);
        void IncreaseScore(string playerName, int amount);
    }
}