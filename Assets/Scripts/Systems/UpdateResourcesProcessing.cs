#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;

#endregion

namespace Systems
{
    public class UpdateResourcesProcessing : IEcsRunSystem
    {
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceElement, ResourceUiElementView> resourceEntitiesFilter;
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceAmountChangedEventComponent> changedEventsFilter;

        public void Run()
        {
            if (changedEventsFilter.IsEmpty())
            {
                return;
            }
            
            foreach (var resourceEntityId in resourceEntitiesFilter)
            {
                ref var resourceElement = ref resourceEntitiesFilter.Get1(resourceEntityId);
                ref var resourceUiElementView = ref resourceEntitiesFilter.Get2(resourceEntityId);

                foreach (var changedEventId in changedEventsFilter)
                {
                    ref var resourceAmountChangedEventComponent = ref changedEventsFilter.Get1(changedEventId);

                    if (resourceElement.resourceElementDefinition.uid == resourceAmountChangedEventComponent.uid)
                    {
                        resourceElement.resourceElementDefinition.amount += resourceAmountChangedEventComponent.amount;
                        resourceUiElementView.text.text = resourceElement.resourceElementDefinition.AmountString;
                    }
                }
            }
        }
    }
}