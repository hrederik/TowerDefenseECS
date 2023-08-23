using Helpers.Extensions;
using Leopotam.Ecs;
using Statistics.Components;
using Statistics.Messages;

namespace Statistics.Systems
{
    public class EnemyDeadProcessSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        
        private readonly EcsFilter<EnemyDeadEvent> deadEvents = null;
        private readonly EcsFilter<KillCounter> killCounters = null;
        
        public void Run()
        {
            foreach (var deadEvent in deadEvents)
            {
                foreach (var killCounter in killCounters)
                {
                    ref var counter = ref killCounters.Get1(killCounter);

                    counter.Count++;
                    world.Message(new KillCounterUpdatedEvent());
                }
            }
        }
    }
}