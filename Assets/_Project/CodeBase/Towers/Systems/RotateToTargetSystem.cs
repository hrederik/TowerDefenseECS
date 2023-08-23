using System.Linq;
using Abilities.Components;
using Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Towers.Systems
{
    public class RotateToTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformLink, AttackTargetsHolder> rotatableEntities = null;
        
        public void Run()
        {
            foreach (var rotatableEntity in rotatableEntities)
            {
                ref var transformLink = ref rotatableEntities.Get1(rotatableEntity);
                ref var attackTargetsHolder = ref rotatableEntities.Get2(rotatableEntity);
                
                if (attackTargetsHolder.Targets.Count == 0)
                    continue;

                var target = attackTargetsHolder.Targets.FirstOrDefault();
                
                if (!target.IsAlive())
                    continue;
                
                ref var targetTransformLink = ref target.Get<TransformLink>();

                var transform = transformLink.Transform;
                var targetTransform = targetTransformLink.Transform;

                var direction = targetTransform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}