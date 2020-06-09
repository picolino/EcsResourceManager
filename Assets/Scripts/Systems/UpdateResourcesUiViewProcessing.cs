#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;

#endregion

namespace Systems
{
    public class UpdateResourcesUiViewProcessing : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceUiElementView, ResourceAmountChangedEventComponent> filter;

        private readonly DependencyContainer dependencyContainer;

        public UpdateResourcesUiViewProcessing(DependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Run()
        {
            foreach (var entity in filter)
            {
                ref var resourceUiElementView = ref filter.Get1(entity);
                ref var resourceAmountChangedEventComponent = ref filter.Get2(entity);

                resourceUiElementView.text.text = resourceAmountChangedEventComponent.amount.ToString("N0");
            }
        }
    }
}