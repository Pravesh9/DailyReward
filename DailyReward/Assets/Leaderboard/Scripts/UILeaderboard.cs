using System.Collections.Generic;
using UnityEngine;

public class UILeaderboard : MonoBehaviour
{
    private static UILeaderboard s_instance;
    [SerializeField] private LeaderboardItemPool pool;

    private readonly List<PlayerLeaderboardTile> _activeItems = new();

    void Awake()
    {
        s_instance = this;
    }

    public static void Render_S(List<PlayerData> players)
    {
        s_instance.Render(players);
    }
    private void Render(List<PlayerData> players)
    {
        Clear();

        for (int i = 0; i < players.Count; i++)
        {
            PlayerLeaderboardTile item = pool.Get();

            item.Setup(players[i], i + 1);

            _activeItems.Add(item);
        }
    }

    private void Clear()
    {
        foreach (PlayerLeaderboardTile item in _activeItems)
        {
            pool.Return(item);
        }

        _activeItems.Clear();
    }
}