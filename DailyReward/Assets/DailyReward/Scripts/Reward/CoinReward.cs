using UnityEngine;
public class CoinReward : Reward
{
    private readonly int amount;

    public CoinReward(string rewardId, int amount, RewardSO rewardSO)
        : base(int.Parse(rewardId), rewardSO)
    {
        this.amount = amount;
    }

    protected override void GiveReward()
    {
        // CurrencyManager.Instance.AddCoins(amount);

        Debug.Log($"Added {amount} coins.");
    }
}