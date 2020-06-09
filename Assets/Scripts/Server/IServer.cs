#region Usings

using System;

#endregion

namespace Server
{
    public interface IServer : IDisposable
    {
        event Action<int, double> ResourceChangedEvent;
    }
}