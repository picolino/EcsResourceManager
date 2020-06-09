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
            dependencyContainer.ResourceDisplayElements = new Dictionary<int, IResourceDisplayElement>(dependencyContainer.Configuration.resourceElements.Length);

            for (var i = 0; i < dependencyContainer.Configuration.resourceElements.Length; i++)
            {
                var resourceElement = dependencyContainer.Configuration.resourceElements[i];

                var resourceDisplayElement = Object.Instantiate(dependencyContainer.Configuration.resourceDisplayElementPrefab,
                                                                dependencyContainer.Configuration.resourcePanelCanvas.transform);

                var resourceDisplayElementRectTransform = resourceDisplayElement.GetComponent<RectTransform>();
                resourceDisplayElementRectTransform.anchoredPosition = new Vector2(i * resourceDisplayElementRectTransform.rect.width, 0);

                var resourceDisplayElementBehaviour = resourceDisplayElement.GetComponent<ResourceDisplayElementBehaviour>();
                resourceDisplayElementBehaviour.resource = resourceElement;

                dependencyContainer.ResourceDisplayElements.Add(resourceDisplayElementBehaviour.resource.uid, resourceDisplayElementBehaviour);
            }
            
            dependencyContainer.ResourceIds = dependencyContainer.ResourceDisplayElements.Select(o => o.Key).ToArray();
        }
    }
}