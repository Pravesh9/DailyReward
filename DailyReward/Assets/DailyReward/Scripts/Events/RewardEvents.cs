using System;

namespace DailyReward
{
    public static class RewardEvents
    {
        public static Action<IReward> OnRewardClaimed;

        public static Action<IReward> OnRewardStateChanged;

        public static Action OnRewardsInitialized;
        public static Action<IReward> OnClaimButtonPressed;
    }
}