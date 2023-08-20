using Boot;
using Cooldown.Systems;
using Leopotam.Ecs;

namespace Cooldown
{
    public struct CooldownFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new CooldownProcessSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}