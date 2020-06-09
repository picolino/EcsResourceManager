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
    public class ResourceSpawnProcessing : IEcsRunSystem
    {
        private readonly EcsWorld world;
        private readonly DependencyContainer dependencyContainer;
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceItemComponent> filter;

        public ResourceSpawnProcessing(EcsWorld world, DependencyContainer dependencyContainer)
        {
            this.world = world;
            this.dependencyContainer = dependencyContainer;
        }
        
        public void Run()
        {
            if (filter.IsEmpty())
            {
                var resourceItemGameObject = Object.Instantiate(dependencyContainer.Configuration.resourceItemPrefab,
                                                                new Vector3(dependencyContainer.Random.Next(-3, 4), dependencyContainer.Random.Next(-3, 4), 0),
                                                                Quaternion.identity);
                var resourceItemBehaviour = resourceItemGameObject.GetComponent<ResourceItemBehaviour>();

                var entity = world.NewEntity();
                ref var resourceItemComponent = ref entity.Get<ResourceItemComponent>();
                resourceItemComponent.uid = dependencyContainer.ResourceIds[dependencyContainer.Random.Next(dependencyContainer.ResourceIds.Length)];
                resourceItemComponent.amount = dependencyContainer.Random.Next(-1, 2);
                resourceItemComponent.resourceItem = resourceItemBehaviour;
            }
        }
    }
}