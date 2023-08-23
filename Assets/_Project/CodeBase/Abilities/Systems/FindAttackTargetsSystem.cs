using Abilities.Components;
using Common.Components;
using Cooldown.Components;
using Damage.Components;
using Helpers;
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
                
                if (!abilityOwner.Has<TransformLink>())
                {
                    Debug.LogError($"[{nameof(FindAttackTargetsSystem)}] ability owner has no {nameof(TransformLink)}");
                    continue;
                }

                if (!ability.Has<RadiusValue>())
                {
                    Debug.LogError($"[{nameof(FindAttackTargetsSystem)}] ability owner has no {nameof(RadiusValue)}");
                    continue;
                }
                
                if (!ability.Has<LayerMaskHolder>())
                {
                    Debug.LogError($"Entity has no {nameof(LayerMaskHolder)}");
                    continue;
                }

                ref var targetsHolder = ref abilityOwner.Get<AttackTargetsHolder>();
                
                var position = abilityOwner.Get<TransformLink>().Transform.position;
                var radius = ability.Get<RadiusValue>().Value;
                var layerMask = ability.Get<LayerMaskHolder>().Value;

                targetsHolder.Targets.Clear();
                
                foreach (var target in TargetFinder.TryGetEntitiesInRadiusWithComponent<Health>(position, radius, layerMask))
                {
                    if (targetsHolder.Targets.Count == targetsHolder.Targets.Capacity)
                        break;
                    
                    targetsHolder.Targets.Add(target);
                }

                ability.Get<OnCooldown>().Remaining = ability.Get<CooldownValue>().Value;
            }
        }
    }
}