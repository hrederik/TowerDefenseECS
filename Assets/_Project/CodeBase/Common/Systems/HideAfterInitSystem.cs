using Common.Components;
using Leopotam.Ecs;

namespace Common.Systems
{
    public class HideAfterInitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HideAfterInitTag, GameObjectLink> hideAfterInitTags = null;
        
        public void Run()
        {
            foreach (var hideAfterInitTag in hideAfterInitTags)
            {
                ref var entity = ref hideAfterInitTags.GetEntity(hideAfterInitTag);
                ref var gameObjectLink = ref entity.Get<GameObjectLink>();

                gameObjectLink.GameObject.SetActive(false);
                entity.Del<HideAfterInitTag>();
            }
        }
    }
}