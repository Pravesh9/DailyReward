using UnityEngine;
namespace DailyReward
{

    [CreateAssetMenu(menuName = "Rewards/Reward Data")]
    public class RewardSO : ScriptableObject
    {
        public int day;

        public RewardType rewardType;

        public int amount;

        public Sprite icon;
    }
}