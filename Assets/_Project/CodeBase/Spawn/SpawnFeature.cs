using Boot;
using Leopotam.Ecs;
using Spawn.Systems;

namespace Spawn
{
    public struct SpawnFeature : IFeature
    {
        public void InitSystems(EcsSystems systems)
        {
            systems.Add(new WaveSpawnSystem());
            systems.Add(new SpawnOnceSystem());
            systems.Add(new SpawnRequestProcessSystem());
        }

        public void InitOneFrames(EcsSystems systems) { }
    }
}