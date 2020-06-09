using System;

namespace Behaviours
{
    public interface IResourceGameplayElement : IDisposable
    {
        bool IsTriggered { get; }
    }
}