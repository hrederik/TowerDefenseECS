using Currencies.Components;
using Leopotam.Ecs;

namespace Currencies.Systems
{
    public class CoinsCounterInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld world = null;
        
        public void Init()
        {
            var statisticsEntity = world.NewEntity();
            statisticsEntity.Get<CoinsCounter>();
        }
    }
}