using Boot;
using GameLoop.Messages;
using GameLoop.Systems;
using Leopotam.Ecs;

namespace GameLoop
{
    public struct GameLoopFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new StartGameSystem());
            systems.Add(new FakeGameplaySystem());
            systems.Add(new GameEndListenerSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<GameStartedEvent>();
        }
    }
}