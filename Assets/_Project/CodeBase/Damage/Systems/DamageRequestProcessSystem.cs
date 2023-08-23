using Damage.Components;
using Damage.Messages;
using Helpers.Extensions;
using Leopotam.Ecs;

namespace Damage.Systems
{
    public class DamageRequestProcessSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<DealDamageRequest> damageRequests = null;
        
        public void Run()
        {
            foreach (var damageRequest in damageRequests)
            {
                ref var entity = ref damageRequests.GetEntity(damageRequest);
                ref var request = ref damageRequests.Get1(damageRequest);

                ref var requestTarget = ref request.Target;
                var damage = request.Amount;

                if (!requestTarget.IsAlive()) continue;
                
                if (!requestTarget.Has<Health>())
                {
                    entity.Del<DealDamageRequest>();
                    continue;
                }

                requestTarget.Get<Health>().Value -= damage;
                world.Message(new HealthUpdatedEvent
                {
                    Target = requestTarget,
                    NewValue = requestTarget.Get<Health>().Value
                });
                
                entity.Del<DealDamageRequest>();
            }
        }
    }
}