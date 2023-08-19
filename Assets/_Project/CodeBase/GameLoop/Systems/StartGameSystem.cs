using GameLoop.Messages;
using Helpers.Extensions;
using Leopotam.Ecs;
using SceneLoading;
using SceneLoading.Messages;
using StaticData;

namespace GameLoop.Systems
{
    public class StartGameSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly StaticDataProvider staticDataProvider = null;

        private readonly EcsFilter<SceneLoadedEvent> sceneLoadedEvents = null;

        public void Run()
        {
            foreach (var sceneLoadedEvent in sceneLoadedEvents)
            {
                ref var component = ref sceneLoadedEvents.Get1(sceneLoadedEvent);

                if (!staticDataProvider.TryGetData<ScenesConfig>(out var scenesConfig)) continue;
                if (!component.Name.Equals(scenesConfig.GameSceneName)) continue;
                
                world.Message(new GameStartedEvent());
            }
        }
    }
}