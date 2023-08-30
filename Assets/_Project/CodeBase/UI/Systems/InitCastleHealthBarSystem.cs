using Common.Components;
using Common.MonoComponents;
using Leopotam.Ecs;
using Towers.Components;
using UI.Components;

namespace UI.Systems
{
    public class InitCastleHealthBarSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthBarTarget, InitCastleHealthBarTag> initiableCastleHealthBars = null;
        private readonly EcsFilter<GameObjectLink, CastleTag> castles = null;

        public void Run()
        {
            foreach (var castleHealthBar in initiableCastleHealthBars)
            {
                ref var healthBarEntity = ref initiableCastleHealthBars.GetEntity(castleHealthBar);
                ref var healthBarTarget = ref initiableCastleHealthBars.Get1(castleHealthBar);

                foreach (var castle in castles)
                {
                    ref var castleGameObjectLink = ref castles.Get1(castle);

                    if (!castleGameObjectLink.GameObject.TryGetComponent<EntityLink>(out var entityLink))
                        continue;

                    healthBarTarget.TargetLink = entityLink;
                }
                
                healthBarEntity.Del<InitCastleHealthBarTag>();
            }
        }
    }
}