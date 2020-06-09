#region Usings

using System.Collections.Generic;
using System.Linq;
using Behaviours;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Systems
{
    public class InitializeResourcesProcessing : IEcsInitSystem
    {
        private readonly DependencyContainer dependencyContainer;

        public InitializeResourcesProcessing(DependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Init()
        {
            dependencyContainer.ResourceUiDisplayElements = new Dictionary<int, IResourceUiElementBehaviour>(dependencyContainer.Configuration.resourceUiElements.Length);

            for (var i = 0; i < dependencyContainer.Configuration.resourceUiElements.Length; i++)
            {
                var resourceUiElement = dependencyContainer.Configuration.resourceUiElements[i];

                var resourceUiElementGameObject = Object.Instantiate(dependencyContainer.Configuration.resourceUiElementPrefab,
                                                                     dependencyContainer.Configuration.resourcePanelCanvas.transform);

                var resourceUiElementRectTransform = resourceUiElementGameObject.GetComponent<RectTransform>();
                resourceUiElementRectTransform.anchoredPosition = new Vector2(i * resourceUiElementRectTransform.rect.width, 0);

                var resourceUiElementBehaviour = resourceUiElementGameObject.GetComponent<ResourceUiElementBehaviourBehaviour>();
                resourceUiElementBehaviour.resourceUi = resourceUiElement;

                dependencyContainer.ResourceUiDisplayElements.Add(resourceUiElementBehaviour.resourceUi.uid, resourceUiElementBehaviour);
            }

            dependencyContainer.ResourceIds = dependencyContainer.ResourceUiDisplayElements.Select(o => o.Key).ToArray();
        }
    }
}