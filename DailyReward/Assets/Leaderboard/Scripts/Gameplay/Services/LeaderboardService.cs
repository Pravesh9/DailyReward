using System.Collections.Generic;
using System.Linq;
namespace System.Leaderboard
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly IPlayerFactory _playerFactory;

        private List<PlayerData> _players = new();

        public LeaderboardService(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public void GeneratePlayers(int count)
        {
            _players.Clear();

            for (int i = 0; i < count; i++)
            {
                _players.Add(_playerFactory.CreatePlayer(i));
            }

            SortPlayers();
        }

        public List<PlayerData> GetPlayers()
        {
            return _players;
        }

        public void IncreaseScore(string playerName, int amount)
        {
            PlayerData player =
                _players.FirstOrDefault(p => p.PlayerName == playerName);

            if (player == null)
                return;

            player.Score += amount;

            SortPlayers();
        }

        private void SortPlayers()
        {
            _players = _players
                .OrderByDescending(p => p.Score)
                .ToList();
        }
    }
}