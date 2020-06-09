#region Usings

using System;

#endregion

namespace Behaviours
{
    public interface IResourceItemBehaviour : IDisposable
    {
        bool IsTriggered { get; }
    }
}