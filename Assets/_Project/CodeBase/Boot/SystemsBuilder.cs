using Abilities;
using AI;
using Animation;
using Common.Messages;
using Common.Systems;
using Cooldown;
using Damage;
using GameLoop;
using Leopotam.Ecs;
using PathFollowing;
using SceneLoading;
using Spawn;
using Statistics;
using Towers;
using UI;
using Upgrade;
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
            _systems.Add(new EntityLinkInitSystem());

            InitFeatureSystems<SceneLoadingFeature>();
            InitFeatureSystems<GameLoopFeature>();
            InitFeatureSystems<PathFollowingFeature>();
            InitFeatureSystems<TowersFeature>();
            InitFeatureSystems<AbilitiesFeature>();
            InitFeatureSystems<SpawnFeature>();
            InitFeatureSystems<DamageFeature>();
            InitFeatureSystems<CooldownFeature>();
            InitFeatureSystems<AIFeature>();
            InitFeatureSystems<UpgradeFeature>();
            InitFeatureSystems<AnimationFeature>();
            InitFeatureSystems<StatisticsFeature>();
            InitFeatureSystems<UIFeature>();

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
            _systems.OneFrame<EntityInitialized>();
            
            InitFeatureOneFrames<SceneLoadingFeature>();
            InitFeatureOneFrames<GameLoopFeature>();
            InitFeatureOneFrames<AbilitiesFeature>();
            InitFeatureOneFrames<UpgradeFeature>();
            InitFeatureOneFrames<StatisticsFeature>();
            
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