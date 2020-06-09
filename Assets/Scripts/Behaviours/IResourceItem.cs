using System;

namespace Behaviours
{
    public interface IResourceItem : IDisposable
    {
        bool IsTriggered { get; }
    }
}