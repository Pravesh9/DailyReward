using UnityEngine;
public class GemsReward : Reward
{
    private readonly int amount;

    public GemsReward(string rewardId, int amount, RewardSO rewardSO)
        : base(int.Parse(rewardId), rewardSO)
    {
        this.amount = amount;
    }

    protected override void GiveReward()
    {
        // CurrencyManager.Instance.AddGems(amount);

        Debug.Log($"Added {amount} gems.");
    }
}