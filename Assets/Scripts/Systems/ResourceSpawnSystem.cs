using System;
using Basics;
using Behaviours;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Systems
{
    public class ResourceSpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld world;
        private readonly DependencyContainer dependencyContainer;
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceGameplayElementComponent> filter;

        public ResourceSpawnSystem(EcsWorld world, DependencyContainer dependencyContainer)
        {
            this.world = world;
            this.dependencyContainer = dependencyContainer;
        }
        
        public void Run()
        {
            if (filter.IsEmpty())
            {
                var resourceElement = Object.Instantiate(dependencyContainer.Configuration.resourcePrefab, 
                                                         new Vector3(dependencyContainer.Random.Next(-3, 4), dependencyContainer.Random.Next(-3, 4), 0),
                                                         Quaternion.identity);
                var resourceGameplayElementBehaviour = resourceElement.GetComponent<ResourceGameplayElementBehaviour>();

                var entity = world.NewEntity();
                ref var resourceGameplayElementComponent = ref entity.Get<ResourceGameplayElementComponent>();
                resourceGameplayElementComponent.uid = dependencyContainer.ResourceIds[dependencyContainer.Random.Next(dependencyContainer.ResourceIds.Length)];
                resourceGameplayElementComponent.amount = dependencyContainer.Random.Next(-1, 2);
                resourceGameplayElementComponent.resourceGameplayElement = resourceGameplayElementBehaviour;
            }
        }
    }
}