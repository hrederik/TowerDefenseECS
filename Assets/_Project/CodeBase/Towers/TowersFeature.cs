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
            systems.Add(new TowerUpgradeSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}