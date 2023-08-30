using Damage.Components;
using Damage.Messages;
using Leopotam.Ecs;
using UI.Components;

namespace UI.Systems
{
    public class UpdateHealthBarsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ImageLink, HealthBarTarget> healthBars = null;
        private readonly EcsFilter<HealthUpdatedEvent> healthUpdatedEvents = null;
        
        public void Run()
        {
            foreach (var healthBar in healthBars)
            {
                ref var healthBarImage = ref healthBars.Get1(healthBar);
                ref var healthBarTarget = ref healthBars.Get2(healthBar);

                foreach (var healthUpdatedEvent in healthUpdatedEvents)
                {
                    ref var updatedEvent = ref healthUpdatedEvents.Get1(healthUpdatedEvent);

                    ref var target = ref updatedEvent.Target;
                    var value = updatedEvent.NewValue;
                
                    if (!target.IsAlive())
                        continue;
                    
                    if (!target.Has<BaseHealth>())
                        continue;
                    
                    if (healthBarTarget.TargetLink == null)
                        continue;

                    if (!target.AreIdEquals(healthBarTarget.TargetLink.Entity)) 
                        continue;

                    if (healthBarImage.Image == null)
                        continue;
                    
                    healthBarImage.Image.fillAmount = (float) value / target.Get<BaseHealth>().Value;
                }
            }
        }
    }
}