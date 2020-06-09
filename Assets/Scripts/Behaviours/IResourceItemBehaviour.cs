using System;

namespace Behaviours
{
    public interface IResourceItemBehaviour : IDisposable
    {
        bool IsTriggered { get; }
    }
}