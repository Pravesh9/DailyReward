using System.Collections.Generic;
using UnityEngine;
namespace System.Leaderboard
{
    public class LeaderboardItemPool : MonoBehaviour,
        IObjectPool<PlayerLeaderboardTile>
    {
        [SerializeField] private PlayerLeaderboardTile prefab;
        [SerializeField] private Transform parent;

        private readonly Queue<PlayerLeaderboardTile> _pool = new();

        public PlayerLeaderboardTile Get()
        {
            if (_pool.Count > 0)
            {
                PlayerLeaderboardTile item = _pool.Dequeue();
                item.gameObject.SetActive(true);
                return item;
            }

            return Instantiate(prefab, parent);
        }

        public void Return(PlayerLeaderboardTile item)
        {
            item.gameObject.SetActive(false);
            _pool.Enqueue(item);
        }
    }
}