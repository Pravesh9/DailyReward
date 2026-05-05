using System;

public class DailyClaimValidator : IClaimValidator
{
    public bool CanClaimToday(string lastClaimDate)
    {
        if (string.IsNullOrEmpty(lastClaimDate))
            return true;

        DateTime lastDate = DateTime.Parse(lastClaimDate);

        return DateTime.UtcNow.Date > lastDate.Date;
    }
}