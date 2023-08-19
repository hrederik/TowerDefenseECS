using Leopotam.Ecs;

namespace Boot
{
    public interface IFeature
    {
        void InitSystems(EcsSystems systems);
        void InitOneFrames(EcsSystems systems);
    }
}