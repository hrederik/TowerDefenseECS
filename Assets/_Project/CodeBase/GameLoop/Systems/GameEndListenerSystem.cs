using GameLoop.Messages;
using Leopotam.Ecs;

namespace GameLoop.Systems
{
    public class GameEndListenerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameEndedEvent> gameEndedEvents = null;
        
        public void Run()
        {
            foreach (var gameEndedEvent in gameEndedEvents)
            {
                ref var entity = ref gameEndedEvents.GetEntity(gameEndedEvent);
                
                entity.Del<GameEndedEvent>();
            }
        }
    }
}