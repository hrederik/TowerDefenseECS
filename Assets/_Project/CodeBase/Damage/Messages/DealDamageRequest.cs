using Leopotam.Ecs;

namespace Damage.Messages
{
    public struct DealDamageRequest
    {
        public EcsEntity Target;
        public int Amount;
    }
}