using System;
namespace DailyReward
{
    public class RewardFactory : IRewardFactory
    {
        public IReward CreateReward(RewardSO rewardData)
        {
            switch (rewardData.rewardType)
            {
                case RewardType.COINS:
                    return new CoinReward(
                        rewardData.day.ToString(),
                        rewardData.amount, rewardData);

                case RewardType.GEMS:
                    return new GemsReward(
                        rewardData.day.ToString(),
                        rewardData.amount, rewardData);

                case RewardType.ENERGY:
                    return new GemsReward(
                        rewardData.day.ToString(),
                        rewardData.amount, rewardData);

                default:
                    throw new Exception("Unknown reward type");
            }
        }
    }
}