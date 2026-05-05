using UnityEngine;
namespace DailyReward
{
    public class RewardSoundPlayer : MonoBehaviour
    {
        private void OnEnable()
        {
            RewardEvents.OnRewardClaimed += PlaySound;
        }

        private void OnDisable()
        {
            RewardEvents.OnRewardClaimed -= PlaySound;
        }

        private void PlaySound(IReward reward)
        {
            Debug.Log("Play reward sound");
        }
    }
}