using Boot;
using Leopotam.Ecs;
using UI.Systems;

namespace UI
{
    public struct UIFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new UpdateKillLogsSystem());
            systems.Add(new UpdateCoinsCounterSystem());
            systems.Add(new UpdateCastleHealthBarSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}