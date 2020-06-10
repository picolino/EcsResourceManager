#region Usings

using System.Collections.Generic;
using System.Linq;
using Behaviours;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

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
            for (var i = 0; i < dependencyContainer.Configuration.resourceUiElementDefinitions.Length; i++)
            {
                var resourceUiElementDefinition = dependencyContainer.Configuration.resourceUiElementDefinitions[i];

                var resourceUiElementGameObject = Object.Instantiate(dependencyContainer.Configuration.resourceUiElementPrefab,
                                                                     dependencyContainer.Configuration.resourcePanelCanvas.transform);

                var resourceUiElementRectTransform = resourceUiElementGameObject.GetComponent<RectTransform>();
                resourceUiElementRectTransform.anchoredPosition = new Vector2(i * resourceUiElementRectTransform.rect.width, 0);
                var resourceUiElementBehaviour = resourceUiElementGameObject.GetComponent<ResourceUiElementBehaviour>();

                var resourceElementEntity = world.NewEntity();
                
                ref var resourceElement = ref resourceElementEntity.Get<ResourceElement>();
                resourceElement.resourceElementDefinition = resourceUiElementDefinition;
                
                ref var resourceUiElementViewComponent = ref resourceElementEntity.Get<ResourceUiElementView>();
                resourceUiElementViewComponent.text = resourceUiElementBehaviour.amountDisplayText;
                resourceUiElementViewComponent.image = resourceUiElementBehaviour.iconDisplayImage;
                
                resourceUiElementViewComponent.image.sprite = resourceUiElementDefinition.image;
                resourceUiElementViewComponent.text.text = resourceUiElementDefinition.AmountString;
            }
        }
    }
}