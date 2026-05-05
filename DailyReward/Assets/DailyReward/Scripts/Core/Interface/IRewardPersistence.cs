public interface IRewardPersistence
{
    int GetLastClaimedDay();
    void SaveLastClaimedDay(int day);

    string GetLastClaimDate();
    void SaveLastClaimDate(string date);
}