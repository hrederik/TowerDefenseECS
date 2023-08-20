using Animation;
using Cooldown;
using GameLoop;
using Leopotam.Ecs;
using PathFollowing;
using SceneLoading;
using Spawn;
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
            InitFeatureSystems<SceneLoadingFeature>();
            InitFeatureSystems<GameLoopFeature>();
            InitFeatureSystems<PathFollowingFeature>();
            InitFeatureSystems<AnimationFeature>();
            InitFeatureSystems<SpawnFeature>();
            InitFeatureSystems<CooldownFeature>();
            
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
            InitFeatureOneFrames<SceneLoadingFeature>();
            InitFeatureOneFrames<GameLoopFeature>();
            
            return this;
        }

        public EcsSystems GetResult()
        {
            _systems.Init();
            return _systems;
        }

        private void InitFeatureSystems<T>() where T : struct, IFeature
        {
            new T().InitSystems(_systems);
        }
        
        private void InitFeatureOneFrames<T>() where T : struct, IFeature
        {
            new T().InitOneFrames(_systems);
        }
    }
}