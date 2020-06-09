#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;

#endregion

namespace Systems
{
    public class UpdateResourcesUiProcessing : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceAmountChangedEventComponent> filter;

        private readonly DependencyContainer dependencyContainer;

        public UpdateResourcesUiProcessing(DependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Run()
        {
            foreach (var entity in filter)
            {
                ref var changeResourceEvent = ref filter.Get1(entity);
                var resourceUiElement = dependencyContainer.ResourceUiDisplayElements[changeResourceEvent.uid];
                resourceUiElement.AddAmount(changeResourceEvent.amount);
            }
        }
    }
}