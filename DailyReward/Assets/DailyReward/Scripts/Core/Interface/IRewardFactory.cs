namespace DailyReward
{
    public interface IRewardFactory
    {
        IReward CreateReward(RewardSO rewardData);
    }
}