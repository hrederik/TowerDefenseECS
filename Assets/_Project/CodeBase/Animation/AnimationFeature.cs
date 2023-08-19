using Animation.Systems;
using Boot;
using Leopotam.Ecs;

namespace Animation
{
    public struct AnimationFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new AnimationSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}