using Leopotam.Ecs;

namespace Damage.Messages
{
    public struct HealthUpdatedEvent
    {
        public EcsEntity Target;
        public int NewValue;
    }
}