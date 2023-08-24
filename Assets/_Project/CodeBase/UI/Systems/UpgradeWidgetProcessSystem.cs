using Common.Components;
using Currencies.Components;
using Helpers.Extensions;
using Leopotam.Ecs;
using UI.Components;
using UI.Messages;

namespace UI.Systems
{
    public class UpgradeWidgetProcessSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        
        private readonly EcsFilter<GameObjectLink, ButtonLink, TextLink, UpgradeWidgetTag> upgradeWidgets = null;
        private readonly EcsFilter<ShowUpgradeWidgetRequest> showRequests = null;
        private readonly EcsFilter<HideUpgradeWidgetRequest> hideRequests = null;
        private readonly EcsFilter<CoinsCounter> coinsCounters = null;

        private EcsEntity target;

        public void Run()
        {
            foreach (var upgradeWidget in upgradeWidgets)
            {
                ref var gameObjectLink = ref upgradeWidgets.Get1(upgradeWidget);

                foreach (var showRequest in showRequests)
                {
                    ref var buttonLink = ref upgradeWidgets.Get2(upgradeWidget);
                    ref var textLink = ref upgradeWidgets.Get3(upgradeWidget);
                    
                    ref var coinsCounter = ref coinsCounters.Get1(0);
                    ref var request = ref showRequests.Get1(showRequest);
                    ref var upgradeTarget = ref request.UpgradeTarget;
                    
                    // TODO: Вынести валидацию
                    buttonLink.Button.interactable = request.Price <= coinsCounter.Count;
                    buttonLink.Button.onClick.RemoveListener(OnUpgradeClicked);
                    buttonLink.Button.onClick.AddListener(OnUpgradeClicked);

                    textLink.Text.text = request.Price.ToString();
                    gameObjectLink.GameObject.SetActive(true);

                    target = upgradeTarget;
                }
                
                foreach (var hideRequest in hideRequests)
                {
                    gameObjectLink.GameObject.SetActive(false);
                    target = default;
                }
            }
        }

        private void OnUpgradeClicked()
        {
            if (!target.IsAlive())
                return;
            
            world.Message(new UpgradeConfirmedEvent
            {
                Target = target
            });
        }
    }
}