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
    public class ResourceItemSpawnProcessing : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceItemComponent> filter;
        
        private readonly EcsWorld world;
        private readonly DependencyContainer dependencyContainer;

        public ResourceItemSpawnProcessing(EcsWorld world, DependencyContainer dependencyContainer)
        {
            this.world = world;
            this.dependencyContainer = dependencyContainer;
        }

        public void Run()
        {
            if (filter.IsEmpty())
            {
                var resourceItemPosition = new Vector3(dependencyContainer.Random.Next(dependencyContainer.Configuration.resourceSpawnItemPositionXMin,
                                                                                       dependencyContainer.Configuration.resourceSpawnItemPositionXMax),
                                                       dependencyContainer.Random.Next(dependencyContainer.Configuration.resourceSpawnItemPositionYMin,
                                                                                       dependencyContainer.Configuration.resourceSpawnItemPositionYMax),
                                                       0);

                var resourceItemGameObject = Object.Instantiate(dependencyContainer.Configuration.resourceItemPrefab,
                                                                resourceItemPosition,
                                                                Quaternion.identity);
                
                var resourceItemBehaviour = resourceItemGameObject.GetComponent<ResourceItemBehaviour>();

                var uid = dependencyContainer.ResourceIds[dependencyContainer.Random.Next(dependencyContainer.ResourceIds.Length)];
                var amount = dependencyContainer.Random.Next(dependencyContainer.Configuration.resourceSpawnItemAmountMin,
                                                             dependencyContainer.Configuration.resourceSpawnItemAmountMax);
                
                var entity = world.NewEntity();
                ref var resourceItemComponent = ref entity.Get<ResourceItemComponent>();
                resourceItemComponent.uid = uid;
                resourceItemComponent.amount = amount;
                
                resourceItemBehaviour.Init(world, ref resourceItemComponent, ref entity);
            }
        }
    }
}