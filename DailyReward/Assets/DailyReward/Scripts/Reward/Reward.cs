using UnityEngine;
public abstract class Reward : IReward
{
    public string RewardId { get; protected set; }

    public RewardState State { get; set; }
    public RewardSO rewardSO { get; set; }

    protected Reward(int rewardId, RewardSO rewardSO)
    {
        RewardId = rewardId.ToString();
        this.rewardSO = rewardSO;
    }

    public virtual void Claim()
    {
        if (State != RewardState.CLAIMABLE)
        {
            Debug.Log("Reward cannot be claimed.");
            return;
        }

        GiveReward();

        State = RewardState.CLAIMED;

        Debug.Log($"{RewardId} claimed.");
    }

    protected abstract void GiveReward();
}