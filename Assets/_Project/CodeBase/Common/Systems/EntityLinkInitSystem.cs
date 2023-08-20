using Common.Components;
using Leopotam.Ecs;

namespace Common.Systems
{
    public class EntityLinkInitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EntityLinkRequired> linkRequiredEntities;
        
        public void Run()
        {
            foreach (var linkRequiredEntity in linkRequiredEntities)
            {
                ref var entity = ref linkRequiredEntities.GetEntity(linkRequiredEntity);
                ref var linkRequired = ref linkRequiredEntities.Get1(linkRequiredEntity);

                linkRequired.Link.Entity = entity;
                entity.Del<EntityLinkRequired>();
            }
        }
    }
}