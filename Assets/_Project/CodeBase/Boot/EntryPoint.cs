using Leopotam.Ecs;
using UnityEngine;

namespace Boot
{
    public class EntryPoint : MonoBehaviour
    {
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
                .BuildInjections()
                .BuildOneFrames()
                .GetResult();

            _systems.Init();
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
    }
}