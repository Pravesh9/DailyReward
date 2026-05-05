public interface IReward
{
    string RewardId { get; }
    RewardState State { get; set; }
    RewardSO rewardSO { get; set; }
    void Claim();
}