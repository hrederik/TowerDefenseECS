using Boot;
using Leopotam.Ecs;
using SceneLoading.Systems;

namespace SceneLoading
{
    public struct SceneLoadingFeature : IFeature
    {
        public void Init(EcsSystems systems)
        {
            systems.Add(new SceneLoadingSystem());
        }
    }
}