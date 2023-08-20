using Common.Components;
using Damage.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Damage.Systems
{
    public class DestroyOnReachZeroHealthSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Health, DestroyOnReachZeroHealthTag> reachZeroHealthEntities = null;
        
        public void Run()
        {
            foreach (var reachZeroHealthEntity in reachZeroHealthEntities)
            {
                ref var entity = ref reachZeroHealthEntities.GetEntity(reachZeroHealthEntity);
                ref var healthComponent = ref reachZeroHealthEntities.Get1(reachZeroHealthEntity);

                if (healthComponent.Value > 0) 
                    continue;

                if (!entity.Has<GameObjectLink>())
                {
                    Debug.LogError($"Can't destroy entity because it doesn't contain an {nameof(GameObjectLink)}");
                    continue;
                }
            
                Object.Destroy(entity.Get<GameObjectLink>().GameObject);
                entity.Destroy();
            }
        }
    }
}