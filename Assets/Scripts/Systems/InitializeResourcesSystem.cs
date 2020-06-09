#region Usings

using System.Collections.Generic;
using System.Linq;
using Behaviours;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Systems
{
    public class InitializeResourcesSystem : IEcsInitSystem
    {
        private readonly DependencyContainer dependencyContainer;

        public InitializeResourcesSystem(DependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Init()
        {
            dependencyContainer.ResourceUIDisplayElements = new Dictionary<int, IResourceUIDisplayElement>(dependencyContainer.Configuration.resourceElements.Length);

            for (var i = 0; i < dependencyContainer.Configuration.resourceElements.Length; i++)
            {
                var resourceElement = dependencyContainer.Configuration.resourceElements[i];

                var resourceDisplayElement = Object.Instantiate(dependencyContainer.Configuration.resourceUiDisplayElementPrefab,
                                                                dependencyContainer.Configuration.resourcePanelCanvas.transform);

                var resourceDisplayElementRectTransform = resourceDisplayElement.GetComponent<RectTransform>();
                resourceDisplayElementRectTransform.anchoredPosition = new Vector2(i * resourceDisplayElementRectTransform.rect.width, 0);

                var resourceDisplayElementBehaviour = resourceDisplayElement.GetComponent<ResourceUIDisplayElementBehaviour>();
                resourceDisplayElementBehaviour.resourceUi = resourceElement;

                dependencyContainer.ResourceUIDisplayElements.Add(resourceDisplayElementBehaviour.resourceUi.uid, resourceDisplayElementBehaviour);
            }
            
            dependencyContainer.ResourceIds = dependencyContainer.ResourceUIDisplayElements.Select(o => o.Key).ToArray();
        }
    }
}