using Boot;
using Currencies.Messages;
using Currencies.Systems;
using Leopotam.Ecs;

namespace Currencies
{
    public struct CurrenciesFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new CoinsCounterInitSystem());
            systems.Add(new CoinsCounterProcessSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<CoinsCounterUpdatedEvent>();
        }
    }
}