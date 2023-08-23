using Common.Components;
using Helpers.Extensions;
using Leopotam.Ecs;
using Spawn.Components;
using Spawn.Messages;
using StaticData;
using UnityEngine;

namespace Spawn.Systems
{
    public class SpawnOnceSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly StaticDataProvider staticDataProvider = null;
        private readonly EcsFilter<SpawnableEntityHolder, TransformLink, SpawnOnceTag> spawnPoints = null;
        
        public void Run()
        {
            foreach (var spawnPoint in spawnPoints)
            {
                ref var entity = ref spawnPoints.GetEntity(spawnPoint);
                ref var spawnableEntityHolder = ref spawnPoints.Get1(spawnPoint);
                ref var transformLink = ref spawnPoints.Get2(spawnPoint);

                world.Message(new SpawnRequest
                {
                    Prefab = spawnableEntityHolder.Prefab,
                    Position = transformLink.Transform.position,
                    Rotation = transformLink.Transform.rotation
                });

                if (entity.Has<GameObjectLink>())
                {
                    Object.Destroy(entity.Get<GameObjectLink>().GameObject);
                }

                entity.Destroy();
            }
        }
    }
}