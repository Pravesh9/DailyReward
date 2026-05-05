using UnityEngine;
namespace DailyReward
{

    public class RewardAnalytics
    {
        private void OnEnable()
        {
            RewardEvents.OnRewardClaimed += TrackClaim;
        }

        private void OnDisable()
        {
            RewardEvents.OnRewardClaimed -= TrackClaim;
        }

        private void TrackClaim(IReward reward)
        {
            Debug.Log($"Analytics: {reward.RewardId}");
        }
    }
}