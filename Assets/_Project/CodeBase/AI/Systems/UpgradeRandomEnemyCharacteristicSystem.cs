using AI.Components;
using Common.Messages;
using Helpers.Extensions;
using Leopotam.Ecs;
using Spawn.Components;
using StaticData;
using UnityEngine;
using Upgrade.Messages;

namespace AI.Systems
{
    public class UpgradeRandomEnemyCharacteristicSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly StaticDataProvider dataProvider = null;
        
        private readonly EcsFilter<EnemyTag, EntityInitialized> newEnemies = null;
        private readonly EcsFilter<WaveCounters> waveCounters = null;

        public void Run()
        {
            if (!dataProvider.TryGetData<EnemyUpgradeConfig>(out var upgradeData)) return;
            
            foreach (var waveCounter in waveCounters)
            {
                ref var counters = ref waveCounters.Get1(waveCounter);
                var waveCount = counters.Count - 1;

                foreach (var newEnemy in newEnemies)
                {
                    ref var enemy = ref newEnemies.GetEntity(newEnemy);
                    
                    if (ShouldUpgrade())
                    {
                        world.Message(new UpgradeCharacteristicRequest
                        {
                            Characteristic = UpgradeCharacteristic.AttackDamage,
                            NewValue = waveCount * upgradeData.DamageIncreaseStep,
                            Target = enemy
                        });
                    }
                    
                    if (ShouldUpgrade())
                    {
                        world.Message(new UpgradeCharacteristicRequest
                        {
                            Characteristic = UpgradeCharacteristic.Health,
                            NewValue = waveCount * upgradeData.HealthIncreaseStep,
                            Target = enemy
                        });
                    }
                }
            }
        }

        private bool ShouldUpgrade()
        {
            return Random.Range(0, 100) > 50;
        }
    }
}