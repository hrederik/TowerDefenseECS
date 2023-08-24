using Leopotam.Ecs;

namespace UI.Messages
{
    public struct ShowUpgradeWidgetRequest
    {
        public EcsEntity UpgradeTarget;
        public int Price;
    }
}