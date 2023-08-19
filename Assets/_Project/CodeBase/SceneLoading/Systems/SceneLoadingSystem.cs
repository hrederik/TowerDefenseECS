using Helpers.Extensions;
using Leopotam.Ecs;
using SceneLoading.Messages;
using UnityEngine.SceneManagement;

namespace SceneLoading.Systems
{
    public class SceneLoadingSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<LoadSceneRequest> requestsFilter = null;
        
        public void Run()
        {
            foreach (var request in requestsFilter)
            {
                ref var entity = ref requestsFilter.GetEntity(request);
                ref var loadSceneRequest = ref requestsFilter.Get1(request);

                LoadScene(loadSceneRequest.Name);
                entity.Del<LoadSceneRequest>();
            }
        }

        private async void LoadScene(string name)
        {
            await SceneManager.LoadSceneAsync(name).GetTask();
            world.Message(new SceneLoadedEvent { Name = name });
        }
    }
}