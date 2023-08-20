using Common.Components;
using Cooldown.Components;
using Helpers.Extensions;
using Leopotam.Ecs;
using Spawn.Components;
using Spawn.Messages;
using StaticData;
using UnityEngine;

namespace Spawn.Systems
{
    public class WaveSpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly StaticDataProvider staticDataProvider = null;
        private readonly EcsFilter<SpawnableEntityHolder, TransformLink, WavedSpawnTag>.Exclude<OnCooldown> spawnPoints = null;
        
        public void Run()
        {
            if (!staticDataProvider.TryGetData<SpawnConfig>(out var spawnConfig)) return;
            
            foreach (var spawnPoint in spawnPoints)
            {
                ref var entity = ref spawnPoints.GetEntity(spawnPoint);
                ref var spawnableEntityHolder = ref spawnPoints.Get1(spawnPoint);
                ref var transformLink = ref spawnPoints.Get2(spawnPoint);
                ref var waveCounters = ref entity.Get<WaveCounters>();
                
                if (waveCounters.Count == 0)
                {
                    waveCounters.Count = 1;
                    waveCounters.MaxEnemiesInCurrentWave = GetMaxEnemyAmountByWave(waveCounters, spawnConfig);
                }

                if (waveCounters.EnemiesInCurrentWave >= waveCounters.MaxEnemiesInCurrentWave)
                {
                    waveCounters.EnemiesInCurrentWave = 0;
                    waveCounters.MaxEnemiesInCurrentWave = GetMaxEnemyAmountByWave(waveCounters, spawnConfig);
                    
                    waveCounters.Count++;
                    entity.Get<OnCooldown>().Remaining = spawnConfig.WaveDelay;
                    continue;
                }

                waveCounters.EnemiesInCurrentWave++;
                entity.Get<OnCooldown>().Remaining = spawnConfig.EnemyDelay;
                
                world.Message(new SpawnRequest
                {
                    Prefab = spawnableEntityHolder.Prefab,
                    Position = transformLink.Transform.position,
                    Rotation = transformLink.Transform.rotation
                });
            }
        }

        private int GetMaxEnemyAmountByWave(WaveCounters waveCounters, SpawnConfig spawnConfig)
        {
            return Random.Range(waveCounters.Count, waveCounters.Count + spawnConfig.UpperWaveBoundOffset);
        }
    }
}