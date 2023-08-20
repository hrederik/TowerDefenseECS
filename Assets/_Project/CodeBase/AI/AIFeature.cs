using Abilities.Systems;
using Boot;
using Leopotam.Ecs;

namespace AI
{
    public struct AIFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new BlockMotionOnHasTargetsSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}