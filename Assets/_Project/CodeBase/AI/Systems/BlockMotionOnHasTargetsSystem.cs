using Abilities.Components;
using Leopotam.Ecs;
using PathFollowing.Components;

namespace Abilities.Systems
{
    public class BlockMotionOnHasTargetsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AttackTarget, InMotionTag> targetHolderEntities = null;
        
        public void Run()
        {
            foreach (var targetHolderEntity in targetHolderEntities)
            {
                ref var entity = ref targetHolderEntities.GetEntity(targetHolderEntity);
                ref var targetHolder = ref targetHolderEntities.Get1(targetHolderEntity);

                if (targetHolder.Target.IsAlive())
                {
                    entity.Get<PathFollowingBlockedTag>();
                    continue;
                }
                
                entity.Del<PathFollowingBlockedTag>();
            }
        }
    }
}