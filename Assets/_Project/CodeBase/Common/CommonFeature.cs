using Boot;
using Common.Messages;
using Common.Systems;
using Leopotam.Ecs;

namespace Common
{
    public struct CommonFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new EntityLinkInitSystem());
            systems.Add(new HideAfterInitSystem());
            systems.Add(new RaycastSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<EntityInitialized>();
            systems.OneFrame<EntitySelectedByRaycastEvent>();
        }
    }
}