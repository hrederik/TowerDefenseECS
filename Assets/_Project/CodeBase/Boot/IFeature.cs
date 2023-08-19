using Leopotam.Ecs;

namespace Boot
{
    public interface IFeature
    {
        void Init(EcsSystems systems);
    }
}