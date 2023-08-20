using Abilities.Messages;
using Animation.Components;
using Helpers;
using Leopotam.Ecs;
using PathFollowing.Components;

namespace Animation.Systems
{
    public class AnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AnimatorLink> animators = null;
        

        public void Run()
        {
            foreach (var animator in animators)
            {
                ref var entity = ref animators.GetEntity(animator);
                ref var animatorLink = ref animators.Get1(animator);
                
                animatorLink.Animator.SetBool(AnimatorParameters.Motion, entity.Has<InMotionTag>() && !entity.Has<PathFollowingBlockedTag>());

                if (entity.Has<AttackEvent>())
                {
                    animatorLink.Animator.SetTrigger(AnimatorParameters.Attack);
                }
            }
        }
    }
}