using Abilities.Components;
using Leopotam.Ecs;

namespace Helpers
{
    public static class EntityExtensions
    {
        public static ref T GetComponent<T>(this ref EcsEntity entity, ref T defaultValue, bool lookInHierarchy = false) where T : struct
        {
            if (entity.Has<T>())
            {
                return ref entity.Get<T>();
            }

            if (!lookInHierarchy)
                return ref defaultValue;
            
            if (entity.Has<AbilitiesHolder>())
            {
                ref var abilitiesHolder = ref entity.Get<AbilitiesHolder>();
                
                foreach (var ability in abilitiesHolder.Abilities)
                {
                    if (!ability.Entity.Has<DamageValue>()) 
                        continue;
                    
                    return ref ability.Entity.Get<T>();
                }
            }

            return ref defaultValue;
        }
    }
}