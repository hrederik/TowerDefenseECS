using Helpers.Extensions;
using Leopotam.Ecs;
using StaticData;
using UI.Messages;
using Upgrade.Components;
using Upgrade.Messages;

namespace Towers.Systems
{
    public class ProcessUpgradeConfirmationSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly StaticDataProvider dataProvider = null;
        
        private readonly EcsFilter<UpgradeConfirmedEvent> upgradeConfirmedEvents = null;

        public void Run()
        {
            if (!dataProvider.TryGetData<TowersUpgradeConfig>(out var upgradeData)) 
                return;
            
            foreach (var upgradeConfirmedEvent in upgradeConfirmedEvents)
            {
                ref var eventComponent = ref upgradeConfirmedEvents.Get1(upgradeConfirmedEvent);
                ref var upgradeEntity = ref eventComponent.Target;
                
                ref var level = ref upgradeEntity.Get<Level>();

                level.Value++;

                world.Message(new UpgradeCharacteristicRequest
                {
                    Characteristic = UpgradeCharacteristic.AttackDamage,
                    NewValue = upgradeData.BaseDamage + upgradeData.DamageStep * level.Value,
                    Target = upgradeEntity
                });
                world.Message(new HideUpgradeWidgetRequest());
            }
        }
    }
}