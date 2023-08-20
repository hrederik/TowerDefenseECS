using Boot;
using Damage.Systems;
using Leopotam.Ecs;

namespace Damage
{
    public struct DamageFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new DamageRequestProcessSystem());
            systems.Add(new DestroyOnReachZeroHealthSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            
        }
    }
}