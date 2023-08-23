using Boot;
using Leopotam.Ecs;
using Statistics.Messages;
using Statistics.Systems;

namespace Statistics
{
    public struct StatisticsFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new StatisticsInitSystem());
            systems.Add(new EnemyDeadProcessSystem());
        }

        public void InitOneFrames(EcsSystems systems)
        {
            systems.OneFrame<EnemyDeadEvent>();
        }
    }
}