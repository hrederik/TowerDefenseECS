using Currencies.Components;
using Currencies.Messages;
using Helpers.Extensions;
using Leopotam.Ecs;
using Statistics.Messages;
using UnityEngine;

namespace Currencies.Systems
{
    public class CoinsCounterProcessSystem : IEcsRunSystem 
    {
        private readonly EcsWorld world = null;
        
        private readonly EcsFilter<EnemyDeadEvent> deadEvents = null;
        private readonly EcsFilter<CoinsCounter> coinsCounters = null;
        
        public void Run()
        {
            foreach (var deadEvent in deadEvents)
            {
                ref var eventComponent = ref deadEvents.Get1(deadEvent);

                foreach (var coinCounter in coinsCounters)
                {
                    ref var counter = ref coinsCounters.Get1(coinCounter);

                    counter.Count += eventComponent.CoinsForKill;
                    world.Message(new CoinsCounterUpdatedEvent { NewValue = counter.Count });
                }
            }
        }
    }
}