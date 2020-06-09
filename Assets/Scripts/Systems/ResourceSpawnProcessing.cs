#region Usings

using Basics;
using Behaviours;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Systems
{
    public class ResourceSpawnProcessing : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceItemComponent> filter;
        
        private readonly EcsWorld world;
        private readonly DependencyContainer dependencyContainer;

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
                var resourceItemBehaviour = resourceItemGameObject.GetComponent<ResourceItemBehaviourBehaviour>();

                var entity = world.NewEntity();
                ref var resourceItemComponent = ref entity.Get<ResourceItemComponent>();
                resourceItemComponent.uid = dependencyContainer.ResourceIds[dependencyContainer.Random.Next(dependencyContainer.ResourceIds.Length)];
                resourceItemComponent.amount = dependencyContainer.Random.Next(-1, 2);
                resourceItemComponent.resourceItemBehaviour = resourceItemBehaviour;
            }
        }
    }
}