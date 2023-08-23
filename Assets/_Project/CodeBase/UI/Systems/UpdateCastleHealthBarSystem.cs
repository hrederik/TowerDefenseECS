using Damage.Components;
using Damage.Messages;
using Leopotam.Ecs;
using Towers.Components;
using UI.Components;
using UnityEngine;

namespace UI.Systems
{
    public class UpdateCastleHealthBarSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ImageLink, CastleHealthBarTag> castleHealthbars = null;
        private readonly EcsFilter<HealthUpdatedEvent> healthUpdatedEvents = null;
        
        public void Run()
        {
            foreach (var healthUpdatedEvent in healthUpdatedEvents)
            {
                ref var updatedEvent = ref healthUpdatedEvents.Get1(healthUpdatedEvent);

                ref var target = ref updatedEvent.Target;
                var value = updatedEvent.NewValue;
                
                if (!target.IsAlive())
                    continue;
                
                if (!target.Has<CastleTag>()) 
                    continue;
                
                if (!target.Has<BaseHealth>())
                    continue;

                foreach (var castleHealthBar in castleHealthbars)
                {
                    ref var healthBar = ref castleHealthbars.Get1(castleHealthBar);
                    healthBar.Image.fillAmount = (float) value / target.Get<BaseHealth>().Value;
                }
            }
        }
    }
}