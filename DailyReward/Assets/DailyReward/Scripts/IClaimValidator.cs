public interface IClaimValidator
{
    bool CanClaimToday(string lastClaimDate);
}