using Leopotam.Ecs;
using Spawn.Messages;
using UnityEngine;

namespace Spawn.Systems
{
    public class SpawnRequestProcessSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnRequest> spawnRequests = null;
        
        public void Run()
        {
            foreach (var spawnRequest in spawnRequests)
            {
                ref var entity = ref spawnRequests.GetEntity(spawnRequest);
                ref var request = ref spawnRequests.Get1(spawnRequest);

                var instance = Object.Instantiate(request.Prefab).transform;

                if (request.Position.HasValue)
                {
                    instance.position = request.Position.Value;
                }

                if (request.Rotation.HasValue)
                {
                    instance.rotation = request.Rotation.Value;
                }

                if (request.Parent != null)
                {
                    instance.SetParent(request.Parent);
                }
                
                entity.Del<SpawnRequest>();
            }
        }
    }
}