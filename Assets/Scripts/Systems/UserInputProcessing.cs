#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Systems
{
    public class UserInputProcessing : IEcsRunSystem, IEcsInitSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<PointToMoveComponent> filter;

        private readonly DependencyContainer dependencyContainer;
        private readonly EcsWorld world;

        public UserInputProcessing(EcsWorld world, DependencyContainer dependencyContainer)
        {
            this.world = world;
            this.dependencyContainer = dependencyContainer;
        }

        public void Init()
        {
            var movePointEntity = world.NewEntity();
            ref var component = ref movePointEntity.Get<PointToMoveComponent>();
            component.position = dependencyContainer.Configuration.player.transform.position;
        }

        public void Run()
        {
            if (Input.GetMouseButton(0))
            {
                foreach (var entity in filter)
                {
                    ref var pointToMoveComponent = ref filter.Get1(entity);
                    pointToMoveComponent.position = dependencyContainer.Configuration.mainCamera.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
    }
}