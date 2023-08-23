using Boot;
using Leopotam.Ecs;
using Towers.Systems;

namespace Towers
{
    public struct TowersFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new RotateToTargetSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}