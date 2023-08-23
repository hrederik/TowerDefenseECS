using AI.Components;
using Common.Components;
using Damage.Components;
using Helpers.Extensions;
using Leopotam.Ecs;
using Statistics.Messages;
using UnityEngine;

namespace Damage.Systems
{
    public class DestroyOnReachZeroHealthSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
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

                // TODO: Исправить - Завести систему удаления энтити по запросу (энтити должна удаляться не сразу, чтобы мир успел обработать удаление) 
                if (entity.Has<EnemyTag>())
                {
                    world.Message(new EnemyDeadEvent());
                }
                
                Object.Destroy(entity.Get<GameObjectLink>().GameObject);
                entity.Destroy();
            }
        }
    }
}