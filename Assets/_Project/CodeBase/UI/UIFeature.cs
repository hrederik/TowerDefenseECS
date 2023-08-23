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
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}