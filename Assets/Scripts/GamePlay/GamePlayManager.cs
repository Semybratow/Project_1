using System;
using DefaultNamespace.Player;
using UnityEngine;

namespace GamePlay
{
    public class GamePlayManager : MonoBehaviour
    {
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private SpawnerPlatform spawnerPlatform;
        private void Start()
        {
            if (playerManager != null || spawnerPlatform != null)
            {
                Debug.Log("GamePlayManager services loaded");
            }
            else
            {
                Debug.Log("GamePlayManager services unloaded");
            }
        }

        private void Update()
        {
            playerManager?.PlayerService();
            spawnerPlatform?.PlatformToSpawn();
        }
    }
}