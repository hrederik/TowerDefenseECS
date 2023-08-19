using System.Threading.Tasks;
using GameLoop.Messages;
using Helpers.Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLoop.Systems
{
    public class FakeGameplaySystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<GameStartedEvent> gameStartedEvents = null;
        
        public void Run()
        {
            foreach (var gameStartedEvent in gameStartedEvents)
            {
                Debug.Log("Game started");
                GameEnd();
            }
        }

        private async void GameEnd()
        {
            await Task.Delay(5000);
            
            world.Message(new GameEndedEvent());
            Debug.Log("Game ended");
        }
    }
}