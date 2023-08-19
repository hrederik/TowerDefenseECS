using Common.Components;
using Leopotam.Ecs;
using PathFollowing.Components;
using UnityEngine;

namespace PathFollowing.Systems
{
    public class PathFollowingSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PathHolder> pathHolders = null;
        private readonly EcsFilter<TargetPathPoint, PathFollowingCharacteristics, TransformLink>.Exclude<PathFollowingBlockedTag> pathFollowers = null;

        public void Run()
        {
            foreach (var pathHolder in pathHolders)
            {
                ref var pathHolderComponent = ref pathHolders.Get1(pathHolder);
                
                foreach (var pathFollower in pathFollowers)
                {
                    ref var entity = ref pathFollowers.GetEntity(pathFollower);
                    ref var targetPathPoint = ref pathFollowers.Get1(pathFollower);
                    ref var pathFollowingCharacteristics = ref pathFollowers.Get2(pathFollower);
                    ref var transformLink = ref pathFollowers.Get3(pathFollower);

                    if (targetPathPoint.Index >= pathHolderComponent.Path.Length)
                    {
                        entity.Get<PathFollowingBlockedTag>();
                        entity.Del<InMotionTag>();
                        continue;
                    }
                    
                    var position = transformLink.Transform.position;
                    var destination = pathHolderComponent.Path[targetPathPoint.Index].position;
                    
                    var direction = destination - position;
                    var newPosition = position + direction.normalized * pathFollowingCharacteristics.Speed * Time.deltaTime;

                    var fromRotation = transformLink.Transform.rotation;
                    var toRotation = Quaternion.LookRotation(direction);
                    var newRotation = Quaternion.Lerp(fromRotation, toRotation, pathFollowingCharacteristics.RotationSpeed * Time.deltaTime);
                    
                    transformLink.Transform.SetPositionAndRotation(newPosition, newRotation);
                    entity.Get<InMotionTag>();

                    if (direction.sqrMagnitude <= 0.25f)
                    {
                        targetPathPoint.Index++;
                    }
                }
            }
        }
    }
}