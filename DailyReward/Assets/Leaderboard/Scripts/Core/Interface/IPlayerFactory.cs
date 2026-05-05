namespace System.Leaderboard
{
    public interface IPlayerFactory
    {
        PlayerData CreatePlayer(int index);
    }
}