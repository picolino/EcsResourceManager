using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class UserInputProcessing : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<PointToMoveComponent> filter;
        
        private readonly Configuration configuration;
        private readonly EcsWorld world;

        public UserInputProcessing(Configuration configuration, EcsWorld world)
        {
            this.configuration = configuration;
            this.world = world;
        }
        
        public void Run()
        {
            if (Input.GetMouseButton(0))
            {
                foreach (var entity in filter)
                {
                    filter.GetEntity(entity).Destroy();
                }
                
                var movePointEntity = world.NewEntity();
                ref var component = ref movePointEntity.Get<PointToMoveComponent>();
                component.position = configuration.mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
}