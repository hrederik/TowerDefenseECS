using Common.Messages;
using Helpers.Extensions;
using Leopotam.Ecs;
using StaticData;
using Towers.Components;
using UI.Messages;
using Upgrade.Components;

namespace Towers.Systems
{
    public class ProcessTowerSelectionSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly StaticDataProvider dataProvider = null;

        private readonly EcsFilter<EntitySelectedByRaycastEvent> selectedEntities = null;
        
        public void Run()
        {
            if (!dataProvider.TryGetData<TowersUpgradeConfig>(out var upgradeData)) 
                return;

            foreach (var selectedEntity in selectedEntities)
            {
                ref var eventComponent = ref selectedEntities.Get1(selectedEntity);
                ref var upgradeEntity = ref eventComponent.EntityLink.Entity;

                if (!upgradeEntity.Has<TowerTag>())
                {
                    world.Message(new HideUpgradeWidgetRequest());
                    continue;
                }
                
                ref var level = ref upgradeEntity.Get<Level>();

                var newPrice = upgradeData.BasePrice + level.Value * upgradeData.PriceIncreaseStep;
            
                world.Message(new ShowUpgradeWidgetRequest
                {
                    UpgradeTarget = upgradeEntity,
                    Price = newPrice
                });
            }
        }
    }
}