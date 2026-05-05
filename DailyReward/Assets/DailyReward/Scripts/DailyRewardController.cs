using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardController : MonoBehaviour
{
    private static DailyRewardController s_instance;
    [SerializeField] private List<RewardSO> rewardConfigs;

    private readonly List<IReward> rewards = new();

    private IRewardFactory rewardFactory;
    private IRewardPersistence persistence;
    private IClaimValidator validator;

    private void Awake()
    {
        s_instance = this;
    }
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        rewardFactory = new RewardFactory();
        persistence = new PlayerPrefsRewardPersistence();
        validator = new DailyClaimValidator();

        InitializeRewards();
        RegisterMethod();
    }

    private void RegisterMethod()
    {
        RewardEvents.OnClaimButtonPressed += ClaimReward;
    }
    private void OnDisable()
    {
        RewardEvents.OnClaimButtonPressed -= ClaimReward;
    }

    private void InitializeRewards()
    {
        rewards.Clear();

        foreach (var config in rewardConfigs)
        {
            IReward reward = rewardFactory.CreateReward(config);

            rewards.Add(reward);
        }

        SetRewardStates();
        UIDailyReward.Init_S(rewards);
        RewardEvents.OnRewardsInitialized?.Invoke();
    }

    private void SetRewardStates()
    {
        int lastClaimedDay =
            persistence.GetLastClaimedDay();

        bool canClaimToday =
            validator.CanClaimToday(
                persistence.GetLastClaimDate());

        foreach (var reward in rewards)
        {
            RewardState oldState = reward.State;

            int rewardDay =
                int.Parse(reward.RewardId);

            if (rewardDay <= lastClaimedDay)
            {
                reward.State = RewardState.CLAIMED;
            }
            else if (rewardDay == lastClaimedDay + 1
                     && canClaimToday)
            {
                reward.State = RewardState.CLAIMABLE;
            }
            else
            {
                reward.State = RewardState.LOCKED;
            }

            if (oldState != reward.State)
            {
                RewardEvents
                    .OnRewardStateChanged
                    ?.Invoke(reward);
            }
        }
    }

    public void ClaimReward(IReward reward)
    {
        reward.Claim();

        persistence.SaveLastClaimedDay(
            int.Parse(reward.RewardId));

        persistence.SaveLastClaimDate(
            DateTime.UtcNow.ToString());

        SetRewardStates();

        RewardEvents.OnRewardClaimed?.Invoke(reward);


        Debug.Log("This is a Claim Reward! " + reward.rewardSO.day);
    }
}