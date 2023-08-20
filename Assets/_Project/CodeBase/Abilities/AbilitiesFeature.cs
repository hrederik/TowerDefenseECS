using Abilities.Messages;
using Abilities.Systems;
using Boot;
using Leopotam.Ecs;

namespace Abilities
{
    public struct AbilitiesFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new FindAttackTargetsSystem());
            systems.Add(new SimpleAttackSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<AttackEvent>();
        }
    }
}