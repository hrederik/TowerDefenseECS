using Boot;
using Leopotam.Ecs;
using SceneLoading.Messages;
using SceneLoading.Systems;

namespace SceneLoading
{
    public struct SceneLoadingFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new SceneLoadingSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<SceneLoadedEvent>();
        }
    }
}