using Cooldown.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Cooldown.Systems
{
    public class CooldownProcessSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OnCooldown> cooldowns = null;
        
        public void Run()
        {
            foreach (var cooldown in cooldowns)
            {
                ref var entity = ref cooldowns.GetEntity(cooldown);
                ref var onCooldown = ref cooldowns.Get1(cooldown);
                
                onCooldown.Remaining -= Time.deltaTime;
                
                if (onCooldown.Remaining <= 0)
                {
                    entity.Del<OnCooldown>();
                }
            }
        }
    }
}