using Helpers.Extensions;
using Leopotam.Ecs;
using SceneLoading;
using SceneLoading.Messages;
using StaticData;
using UnityEngine;

namespace Boot
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private StaticDataProvider _staticDataProvider;

        private EcsWorld _world;
        private EcsSystems _systems;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new SystemsBuilder(_world)
                .BuildSceneConversion()
                .BuildFeatures()
                .BuildInjections(_staticDataProvider)
                .BuildOneFrames()
                .GetResult();

            _staticDataProvider.Init();
            LoadGameScene();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }

        private void LoadGameScene()
        {
            if (!_staticDataProvider.TryGetData<ScenesConfig>(out var scenesConfig))
            {
                Debug.LogError("Failed to load game scene because SceneConfig could not be found");
                return;
            }
            
            _world.Message(new LoadSceneRequest {Name = scenesConfig.GameSceneName});
        }
    }
}