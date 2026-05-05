using System.Collections.Generic;
using UnityEngine;

public class UIDailyReward : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private Transform rewardContainer;

    [SerializeField]
    private RewardTile rewardTilePrefab;

    private readonly List<RewardTile> spawnedTiles = new();
    private static UIDailyReward s_instance;

    private void Awake()
    {
        s_instance = this;
    }
    public static void Init_S(List<IReward> rewards)
    {
        s_instance.Init(rewards);
    }
    /// <summary>
    /// Initialize Daily Reward UI
    /// Spawns reward tiles dynamically.
    /// </summary>
    private void Init(List<IReward> rewards)
    {
        ClearExistingTiles();

        foreach (IReward reward in rewards)
        {
            CreateRewardTile(reward);
        }
    }

    private void CreateRewardTile(IReward reward)
    {
        RewardTile tile =
            Instantiate(
                rewardTilePrefab,
                rewardContainer);

        tile.Initialize(reward);

        spawnedTiles.Add(tile);
    }

    private void ClearExistingTiles()
    {
        foreach (RewardTile tile in spawnedTiles)
        {
            if (tile != null)
            {
                Destroy(tile.gameObject);
            }
        }

        spawnedTiles.Clear();
    }
}