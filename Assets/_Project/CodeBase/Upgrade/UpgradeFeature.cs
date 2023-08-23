using Boot;
using Leopotam.Ecs;
using Upgrade.Messages;
using Upgrade.Systems;

namespace Upgrade
{
    public struct UpgradeFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new UpgradeCharacteristicSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<UpgradeCharacteristicRequest>();
        }
    }
}