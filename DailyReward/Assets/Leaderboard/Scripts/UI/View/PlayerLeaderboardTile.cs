using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace System.Leaderboard
{
    public class PlayerLeaderboardTile : MonoBehaviour
    {
        [SerializeField] private TMP_Text rankText;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button scoreIncrementalBtn;

        private PlayerData _data;

        public PlayerData Data => _data;

        public void Setup(PlayerData data, int rank)
        {
            _data = data;

            rankText.text = rank.ToString();
            nameText.text = data.PlayerName;
            scoreText.text = data.Score.ToString();
        }
        void OnEnable()
        {
            scoreIncrementalBtn.onClick.AddListener(OnClickBtn_ScoreIncremental);
        }
        private void OnClickBtn_ScoreIncremental()
        {
            LeaderboardController.OnClickIncreaseScore_S(_data);
        }

        private void OnDisable()
        {
            scoreIncrementalBtn.onClick.RemoveListener(OnClickBtn_ScoreIncremental);
        }
    }
}