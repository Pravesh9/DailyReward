namespace System.Leaderboard
{
    public interface IObjectPool<T>
    {
        T Get();
        void Return(T item);
    }
}