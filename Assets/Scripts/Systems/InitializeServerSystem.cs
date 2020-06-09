﻿#region Usings

using Leopotam.Ecs;
using Server;

#endregion

namespace Systems
{
    public class InitializeServerSystem : IEcsInitSystem
    {
        private readonly DependencyContainer dependencyContainer;

        public InitializeServerSystem(DependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Init()
        {
            dependencyContainer.Server = new ServerStub(dependencyContainer.ServerStubConfiguration, dependencyContainer.Random, dependencyContainer.ResourceIds);
        }
    }
}