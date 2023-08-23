using Abilities.Components;
using Common.Components;
using Cooldown.Components;
using Damage.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Abilities.Systems
{
    public class FindAttackTargetsSystem : IEcsRunSystem
    {
        private EcsWorld world;
        private readonly EcsFilter<OwnerLink, AbilityFindTargetsTag>.Exclude<OnCooldown> findAbilities = null;

        public void Run()
        {
            foreach (var findAbility in findAbilities)
            {
                ref var ability = ref findAbilities.GetEntity(findAbility);
                ref var abilityOwner = ref findAbilities.Get1(findAbility).Link.Entity;
                
                // TODO: Заменить на DeathTag
                if (!abilityOwner.IsAlive())
                {
                    ability.Destroy();
                    continue;
                }
                
                if (!abilityOwner.Has<TriggerLink>())
                {
                    Debug.LogError($"[{nameof(FindAttackTargetsSystem)}] ability owner has no {nameof(TriggerLink)}");
                    continue;
                }
                
                ref var target = ref abilityOwner.Get<AttackTarget>();

                foreach (var triggeredEntity in abilityOwner.Get<TriggerLink>().Trigger.EntitiesInTrigger)
                {
                    if (!triggeredEntity.Entity.IsAlive()) continue;
                    if (!triggeredEntity.Entity.Has<Health>()) continue;

                    target.Target = triggeredEntity.Entity;
                    break;
                }

                ability.Get<OnCooldown>().Remaining = ability.Get<CooldownValue>().Value;
            }
        }
    }
}