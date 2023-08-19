using Leopotam.Ecs;
using SceneLoading;
using Voody.UniLeo;

namespace Boot
{
    public class SystemsBuilder
    {
        private readonly EcsSystems _systems;

        public SystemsBuilder(EcsWorld world)
        {
            _systems = new EcsSystems(world);
        }

        public SystemsBuilder BuildSceneConversion()
        {
            _systems.ConvertScene();
            return this;
        }
        
        public SystemsBuilder BuildFeatures()
        {
            new SceneLoadingFeature().Init(_systems);
            
            return this;
        }

        public SystemsBuilder BuildInjections()
        {
            return this;
        }
        
        public SystemsBuilder BuildOneFrames()
        {
            return this;
        }

        public EcsSystems GetResult()
        {
            _systems.Init();
            return _systems;
        }
    }
}