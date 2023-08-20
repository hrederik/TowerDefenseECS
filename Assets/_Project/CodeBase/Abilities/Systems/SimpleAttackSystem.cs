using System.Linq;
using Abilities.Components;
using Abilities.Messages;
using Common.Components;
using Cooldown.Components;
using Damage.Messages;
using Helpers.Extensions;
using Leopotam.Ecs;
using PathFollowing.Components;
using UnityEngine;

namespace Abilities.Systems
{
    public class SimpleAttackSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<OwnerLink, AbilitySimpleAttackTag>.Exclude<OnCooldown> damageDealers = null;
        
        public void Run()
        {
            foreach (var damageDealer in damageDealers)
            {
                ref var ability = ref damageDealers.GetEntity(damageDealer);
                ref var abilityOwner = ref damageDealers.Get1(damageDealer).Link.Entity;

                if (!abilityOwner.Has<AttackTargetsHolder>())
                {
                    continue;
                }
                
                ref var attackTargetsHolder = ref abilityOwner.Get<AttackTargetsHolder>();

                if (attackTargetsHolder.Targets.Count == 0)
                {
                    continue;
                }
                
                if (!ability.Has<DamageValue>())
                {
                    Debug.LogError($"[{nameof(SimpleAttackSystem)}] ability has no {nameof(DamageValue)}");
                    continue;
                }

                ref var damageValue = ref ability.Get<DamageValue>().Value;
                var firstTarget = attackTargetsHolder.Targets.FirstOrDefault();

                if (firstTarget != default)
                {
                    abilityOwner.Get<AttackEvent>();
                    ability.Get<OnCooldown>().Remaining = ability.Get<CooldownValue>().Value;

                    world.Message(new DealDamageRequest
                    {
                        Target = firstTarget,
                        Amount = damageValue
                    });
                }
            }
        }
    }
}