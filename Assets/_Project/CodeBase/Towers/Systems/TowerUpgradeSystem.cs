using Common.MonoComponents;
using Helpers;
using Helpers.Extensions;
using Leopotam.Ecs;
using StaticData;
using UI.Messages;
using UnityEngine;
using Upgrade.Components;
using Upgrade.Messages;

namespace Towers.Systems
{
    public class TowerUpgradeSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly StaticDataProvider dataProvider = null;
        
        public void Run()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return;

            if (!dataProvider.TryGetData<TowersUpgradeConfig>(out var upgradeData)) 
                return;
            
            var ray = CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (!Physics.Raycast(ray, out var hit, 100))
                return;
            
            if (!hit.transform.gameObject.TryGetComponent<EntityLink>(out var entityLink))
                return;

            ref var entity = ref entityLink.Entity;
            ref var level = ref entityLink.Entity.Get<Level>();

            level.Value++;

            var newPrice = upgradeData.BasePrice + level.Value * upgradeData.PriceIncreaseStep;
            
            world.Message(new ShowUpgradeWidgetRequest
            {
                UpgradeTarget = entity,
                Price = newPrice
            });
            
            // world.Message(new UpgradeCharacteristicRequest
            // {
            //     Characteristic = UpgradeCharacteristic.AttackDamage,
            //     NewValue = upgradeData.BaseDamage + upgradeData.DamageStep * level.Value,
            //     Target = entityLink.Entity
            // });
        }
    }
}