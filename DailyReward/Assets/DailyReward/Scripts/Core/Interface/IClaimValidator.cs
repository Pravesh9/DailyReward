namespace DailyReward
{
    public interface IClaimValidator
    {
        bool CanClaimToday(string lastClaimDate);
    }
}