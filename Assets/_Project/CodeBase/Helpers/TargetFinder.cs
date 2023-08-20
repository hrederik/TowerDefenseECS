using System.Collections.Generic;
using Common.MonoComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Helpers
{
    public static class TargetFinder
    {
        private static readonly Collider[] Colliders = new Collider[5];
        
        public static IEnumerable<EcsEntity> TryGetEntitiesInRadiusWithComponent<T>(Vector3 position, float radius, LayerMask layerMask) where T : struct
        {
            Physics.OverlapSphereNonAlloc(position, radius, Colliders, layerMask);

            for (int i = 0; i < Colliders.Length; i++)
            {
                var collider = Colliders[i];
                
                if (collider == null)
                {
                    continue;
                }

                if (!collider.TryGetComponent(out EntityLink entityLink))
                {
                    Colliders[i] = null;
                    continue;
                }

                if (!entityLink.Entity.IsAlive())
                {
                    Colliders[i] = null;
                    continue;
                }
                
                if (!entityLink.Entity.Has<T>())
                {
                    Colliders[i] = null;
                    continue;
                }

                Colliders[i] = null;
                yield return entityLink.Entity;
            }
        }
    }
}