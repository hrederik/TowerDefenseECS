using Common.Components;
using Leopotam.Ecs;
using StaticData;
using UI.Components;
using UI.Messages;
using UnityEngine;

namespace UI.Systems
{
    public class ScreenManageSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly StaticDataProvider dataProvider = null;

        private readonly EcsFilter<MainCanvasTag, TransformLink> mainCanvases = null; 
        private readonly EcsFilter<ShowScreenRequest> showScreenRequests = null;
        private readonly EcsFilter<HideScreenRequest> hideScreenRequests = null;
        private readonly EcsFilter<ScreenIdentifier> screens = null;

        private ScreensProvider screensProvider;
        
        public void Init()
        {
            dataProvider.TryGetData(out screensProvider);
        }

        public void Run()
        {
            foreach (var hideScreenRequest in hideScreenRequests)
            {
                ref var request = ref hideScreenRequests.Get1(hideScreenRequest);

                foreach (var screen in screens)
                {
                    ref var screenEntity = ref screens.GetEntity(screen);
                    ref var screenIdentifier = ref screens.Get1(screen);
                    
                    if (screenIdentifier.Value != request.Identifier) 
                        continue;
                    
                    if (!screenEntity.Has<GameObjectLink>())
                        continue;

                    ref var gameObjectLink = ref screenEntity.Get<GameObjectLink>();
                    Object.Destroy(gameObjectLink.GameObject);
                }
            }
            
            foreach (var showScreenRequest in showScreenRequests)
            {
                ref var request = ref showScreenRequests.Get1(showScreenRequest);

                if (!screensProvider.TryGet(request.Identifier, out var screenInfo))
                    continue;

                ref var mainCanvasEntity = ref mainCanvases.GetEntity(0);
                ref var mainCanvasTransformLink = ref mainCanvasEntity.Get<TransformLink>();
                
                Object.Instantiate(screenInfo.Prefab, mainCanvasTransformLink.Transform);
            }
        }
    }
}