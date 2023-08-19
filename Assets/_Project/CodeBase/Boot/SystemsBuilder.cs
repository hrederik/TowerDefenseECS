using GameLoop;
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
            new SceneLoadingFeature().InitSystems(_systems);
            new GameLoopFeature().InitSystems(_systems);

            return this;
        }

        public SystemsBuilder BuildInjections(params object[] injections)
        {
            for (var i = 0; i < injections.Length; i++)
            {
                _systems.Inject(injections[i]);
            }

            return this;
        }
        
        public SystemsBuilder BuildOneFrames()
        {
            new SceneLoadingFeature().InitOneFrames(_systems);
            new GameLoopFeature().InitOneFrames(_systems);
            
            return this;
        }

        public EcsSystems GetResult()
        {
            _systems.Init();
            return _systems;
        }
    }
}