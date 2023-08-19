using Boot;
using Leopotam.Ecs;
using PathFollowing.Systems;

namespace PathFollowing
{
    public struct PathFollowingFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new PathFollowingSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}