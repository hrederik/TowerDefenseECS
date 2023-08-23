using Leopotam.Ecs;

namespace Upgrade.Messages
{
    public struct UpgradeCharacteristicRequest
    {
        public UpgradeCharacteristic Characteristic;
        public EcsEntity Target;
        public int NewValue;
    }

    public enum UpgradeCharacteristic
    {
        AttackDamage = 0,
        Health = 1
    }
}