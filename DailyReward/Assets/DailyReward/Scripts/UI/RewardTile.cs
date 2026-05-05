using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class RewardTile : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField] private Button claimButton;

    [SerializeField] private GameObject claimedMark;
    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private Image bg;

    [SerializeField] private Sprite normalBG;
    [SerializeField] private Sprite claimedBG;
    private IReward reward;
    const string DAY = "Day ";
    const string X = "x ";
    public void Initialize(IReward reward)
    {
        this.reward = reward;
        RegisterClick();
        Refresh();
    }

    private void RegisterClick()
    {
        claimButton.onClick.RemoveAllListeners();
        claimButton.onClick.AddListener(OnClaimButtonClicked);
    }

    private void OnClaimButtonClicked()
    {
        RewardEvents.OnClaimButtonPressed?.Invoke(reward);
    }

    private void OnEnable()
    {
        RewardEvents.OnRewardStateChanged += HandleStateChanged;
        RewardEvents.OnRewardClaimed += HandleRewardClaimed;
    }

    private void OnDisable()
    {
        RewardEvents.OnRewardStateChanged -= HandleStateChanged;
        RewardEvents.OnRewardClaimed -= HandleRewardClaimed;
    }

    private void HandleStateChanged(IReward changedReward)
    {
        if (changedReward.RewardId != reward.RewardId)
            return;

        Refresh();
    }

    private void HandleRewardClaimed(IReward claimedReward)
    {
        if (claimedReward.RewardId != reward.RewardId)
            return;

        PlayClaimAnimation();
        Refresh();
    }

    private void Refresh()
    {
        icon.sprite = reward.rewardSO.icon;
        dayText.text = String.Concat(DAY, reward.rewardSO.day);
        rewardText.text = String.Concat(reward.rewardSO.amount.ToString(), X);

        switch (reward.State)
        {
            case RewardState.LOCKED:
                claimButton.interactable = false;
                claimedMark.SetActive(false);
                bg.sprite = normalBG;
                break;

            case RewardState.CLAIMABLE:
                claimButton.interactable = true;
                claimedMark.SetActive(false);
                bg.sprite = claimedBG;
                break;

            case RewardState.CLAIMED:
                claimButton.interactable = false;
                claimedMark.SetActive(true);
                bg.sprite = claimedBG;
                break;
        }
    }

    private void PlayClaimAnimation()
    {
        Debug.Log("Play Claim Animation");
    }
}