using Abilities.Components;
using Damage.Components;
using Helpers;
using Leopotam.Ecs;
using Upgrade.Messages;

namespace Upgrade.Systems
{
    // TODO: Изменить логику после добавления CountersCollection
    public class UpgradeCharacteristicSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UpgradeCharacteristicRequest> requestEntities = null;
        
        public void Run()
        {
            foreach (var requestEntity in requestEntities)
            {
                ref var request = ref requestEntities.Get1(requestEntity);
                ref var requestTarget = ref request.Target;

                switch (request.Characteristic)
                {
                    case UpgradeCharacteristic.AttackDamage:
                        ProcessDamageUpgrade(ref requestTarget, request.NewValue);
                        break;
                    case UpgradeCharacteristic.Health:
                        ProcessHealthUpgrade(ref requestTarget, request.NewValue);
                        break;
                }
            }
        }

        private void ProcessDamageUpgrade(ref EcsEntity target, int value)
        {
            var defaultValue = new DamageValue {Value = -1};
            ref var damageValue = ref target.GetComponent(ref defaultValue, true);
            
            if (damageValue.Value == -1) 
                return;

            damageValue.Value = value;
        }
        
        private void ProcessHealthUpgrade(ref EcsEntity target, int value)
        {
            var defaultValue = new Health {Value = -1};
            ref var healthValue = ref target.GetComponent(ref defaultValue, true);
            
            if (healthValue.Value == -1) 
                return;

            healthValue.Value = value;
        }
    }
}