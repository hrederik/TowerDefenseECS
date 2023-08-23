using Abilities.Components;
using Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Towers.Systems
{
    public class RotateToTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformLink, AttackTarget> rotatableEntities = null;
        
        public void Run()
        {
            foreach (var rotatableEntity in rotatableEntities)
            {
                ref var transformLink = ref rotatableEntities.Get1(rotatableEntity);
                ref var attackTarget = ref rotatableEntities.Get2(rotatableEntity);

                if (!attackTarget.Target.IsAlive())
                    continue;
                
                ref var targetTransformLink = ref attackTarget.Target.Get<TransformLink>();

                var transform = transformLink.Transform;
                var targetTransform = targetTransformLink.Transform;

                var direction = targetTransform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}