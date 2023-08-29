using Boot;
using Leopotam.Ecs;
using UI.Messages;
using UI.Systems;

namespace UI
{
    public struct UIFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new UpdateKillLogsSystem());
            systems.Add(new UpdateCoinsCounterSystem());
            systems.Add(new UpgradeWidgetProcessSystem());
            systems.Add(new UpdateHealthBarsSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<ShowUpgradeWidgetRequest>();
            systems.OneFrame<HideUpgradeWidgetRequest>();
            systems.OneFrame<UpgradeConfirmedEvent>();
        }
    }
}