namespace System.Leaderboard
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IRandomService _randomService;

        public PlayerFactory(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public PlayerData CreatePlayer(int index)
        {
            string playerName = $"Player_{index + 1}";
            int score = _randomService.Range(1000, 100000);

            return new PlayerData(playerName, score);
        }
    }
}