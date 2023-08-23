using Leopotam.Ecs;
using Statistics.Messages;
using UI.Components;
using UnityEngine;

namespace UI.Systems
{
    public class UpdateKillLogsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TextLink, KillCounterTag> killCounters = null;
        private readonly EcsFilter<KillCounterUpdatedEvent> killCounterUpdatedEvents = null;
        
        public void Run()
        {
            foreach (var killCounterUpdatedEvent in killCounterUpdatedEvents)
            {
                ref var updatedEvent = ref killCounterUpdatedEvents.Get1(killCounterUpdatedEvent);
                var value = updatedEvent.NewValue;
                
                foreach (var killCounter in killCounters)
                {
                    ref var textLink = ref killCounters.Get1(killCounter);
                    textLink.Text.text = value.ToString();
                }
            }
        }
    }
}