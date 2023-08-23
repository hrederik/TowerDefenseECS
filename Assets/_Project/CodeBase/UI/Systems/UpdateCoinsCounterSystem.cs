using Currencies.Messages;
using Leopotam.Ecs;
using UI.Components;

namespace UI.Systems
{
    public class UpdateCoinsCounterSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TextLink, CoinsCounterTag> coinsCounters = null;
        private readonly EcsFilter<CoinsCounterUpdatedEvent> coinsCounterUpdatedEvents = null;
        
        public void Run()
        {
            foreach (var coinsCounterUpdatedEvent in coinsCounterUpdatedEvents)
            {
                ref var updatedEvent = ref coinsCounterUpdatedEvents.Get1(coinsCounterUpdatedEvent);
                var value = updatedEvent.NewValue;
                
                foreach (var coinsCounter in coinsCounters)
                {
                    ref var textLink = ref coinsCounters.Get1(coinsCounter);
                    textLink.Text.text = value.ToString();
                }
            }
        }
    }
}