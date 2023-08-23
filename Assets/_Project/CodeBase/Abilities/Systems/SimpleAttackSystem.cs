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

                // TODO: Заменить на DeathTag
                if (!abilityOwner.IsAlive())
                {
                    ability.Destroy();
                    continue;
                }
                
                if (!abilityOwner.Has<AttackTarget>())
                {
                    continue;
                }

                ref var attackTarget = ref abilityOwner.Get<AttackTarget>();

                if (!attackTarget.Target.IsAlive())
                {
                    continue;
                }
                
                if (!ability.Has<DamageValue>())
                {
                    Debug.LogError($"[{nameof(SimpleAttackSystem)}] ability has no {nameof(DamageValue)}");
                    continue;
                }

                ref var damageValue = ref ability.Get<DamageValue>().Value;
                ref var firstTarget = ref attackTarget.Target;

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