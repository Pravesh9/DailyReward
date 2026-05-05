using UnityEngine;
namespace DailyReward
{
    public class PlayerPrefsRewardPersistence : IRewardPersistence
    {
        private const string LastClaimedDayKey = "LAST_DAY";
        private const string LastClaimDateKey = "LAST_DATE";

        public int GetLastClaimedDay()
        {
            return PlayerPrefs.GetInt(LastClaimedDayKey, 0);
        }

        public void SaveLastClaimedDay(int day)
        {
            PlayerPrefs.SetInt(LastClaimedDayKey, day);
        }

        public string GetLastClaimDate()
        {
            return PlayerPrefs.GetString(LastClaimDateKey, "");
        }

        public void SaveLastClaimDate(string date)
        {
            PlayerPrefs.SetString(LastClaimDateKey, date);
        }
    }
}