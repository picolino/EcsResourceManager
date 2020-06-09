#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Systems
{
    public class PlayerMotionSystem : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<PointToMoveComponent> filter;
        private readonly Configuration configuration;

        public PlayerMotionSystem(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public void Run()
        {
            foreach (var entity in filter)
            {
                ref var pointToMoveComponent = ref filter.Get1(entity);

                configuration.player.transform.position = Vector2.Lerp(configuration.player.transform.position, 
                                                                       pointToMoveComponent.position, 
                                                                       Time.deltaTime);
            }
        }
    }
}