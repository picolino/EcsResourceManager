#region Usings

using Behaviours;
using Components;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Systems
{
    public class InitializeResourcesProcessing : IEcsInitSystem
    {
        private readonly EcsWorld world;
        private readonly DependencyContainer dependencyContainer;

        public InitializeResourcesProcessing(EcsWorld world, DependencyContainer dependencyContainer)
        {
            this.world = world;
            this.dependencyContainer = dependencyContainer;
        }

        public void Init()
        {
            for (var i = 0; i < dependencyContainer.Configuration.resourceElementDefinitions.Length; i++)
            {
                var resourceElementDefinition = dependencyContainer.Configuration.resourceElementDefinitions[i];

                var resourceUiElementGameObject = Object.Instantiate(dependencyContainer.Configuration.resourceUiElementPrefab,
                                                                     dependencyContainer.Configuration.resourcePanelCanvas.transform);

                var resourceUiElementRectTransform = resourceUiElementGameObject.GetComponent<RectTransform>();
                resourceUiElementRectTransform.anchoredPosition = new Vector2(i * resourceUiElementRectTransform.rect.width, 0);
                var resourceUiElementBehaviour = resourceUiElementGameObject.GetComponent<ResourceUiElementBehaviour>();

                var resourceElementEntity = world.NewEntity();
                
                ref var resourceElementComponent = ref resourceElementEntity.Get<ResourceElementComponent>();
                resourceElementComponent.resourceElementDefinition = resourceElementDefinition;
                
                ref var resourceUiElementViewComponent = ref resourceElementEntity.Get<ResourceUiElementViewComponent>();
                resourceUiElementViewComponent.text = resourceUiElementBehaviour.amountDisplayText;
                resourceUiElementViewComponent.image = resourceUiElementBehaviour.iconDisplayImage;
                
                resourceUiElementViewComponent.image.sprite = resourceElementDefinition.image;
                resourceUiElementViewComponent.text.text = resourceElementDefinition.AmountString;
            }
        }
    }
}