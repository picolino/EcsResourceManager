#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Systems
{
    public class PlayerMovementProcessing : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<PointToMoveComponent> filter;
        
        private readonly DependencyContainer dependencyContainer;

        public PlayerMovementProcessing(DependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Run()
        {
            foreach (var entity in filter)
            {
                ref var pointToMoveComponent = ref filter.Get1(entity);

                dependencyContainer.Configuration.player.transform.position = Vector2.Lerp(dependencyContainer.Configuration.player.transform.position,
                                                                                           pointToMoveComponent.position,
                                                                                           dependencyContainer.Configuration.playerSpeed * Time.deltaTime);
            }
        }
    }
}