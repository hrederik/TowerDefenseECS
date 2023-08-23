using AI.Systems;
using Boot;
using Leopotam.Ecs;

namespace AI
{
    public struct AIFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new BlockMotionOnHasTargetsSystem());
            systems.Add(new UpgradeRandomEnemyCharacteristicSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}