using UnityEngine;

namespace System.Leaderboard
{
    public class LeaderboardController : MonoBehaviour
    {
        private static LeaderboardController s_instance;
        private ILeaderboardService leaderboardService;
        [SerializeField] private int playerCount = 30;
        const int SCORE_INCREMENT = 1000;
        private void Awake()
        {
            s_instance = this;
        }
        void Start()
        {
            Init();
        }
        public static void OnClickIncreaseScore_S(PlayerData playerData)
        {
            s_instance.OnClickIncreaseScore(playerData);
        }
        private void Init()
        {
            IRandomService randomService = new RandomService();
            IPlayerFactory playerFactory = new PlayerFactory(randomService);

            leaderboardService = new LeaderboardService(playerFactory);
            leaderboardService.GeneratePlayers(playerCount);

            RefreshUI();
        }

        public void IncreaseRandomPlayerScore()
        {
            var players = leaderboardService.GetPlayers();
            int randomIndex = UnityEngine.Random.Range(0, players.Count);
            string playerName = players[randomIndex].PlayerName;
            leaderboardService.IncreaseScore(playerName, 5000);
            RefreshUI();
        }

        private void RefreshUI()
        {
            UILeaderboard.Render_S(leaderboardService.GetPlayers());
        }

        private void OnClickIncreaseScore(PlayerData playerData)
        {
            leaderboardService.IncreaseScore(playerData.PlayerName, SCORE_INCREMENT);

            RefreshUI();
        }

    }
}