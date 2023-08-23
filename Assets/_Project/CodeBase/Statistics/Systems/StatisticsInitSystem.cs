using Leopotam.Ecs;
using Statistics.Components;

namespace Statistics.Systems
{
    public class StatisticsInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld world = null;
        
        public void Init()
        {
            var statisticsEntity = world.NewEntity();
            statisticsEntity.Get<KillCounter>();
        }
    }
}