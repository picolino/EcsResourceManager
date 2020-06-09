#region Usings

using System;
using System.Collections.Generic;
using Behaviours;
using Server;

#endregion

public class DependencyContainer : IDisposable
{
    public Random Random { get; set; }
    public IServer Server { get; set; }
    public int[] ResourceIds { get; set; }
    public Dictionary<int, IResourceUiElement> ResourceUiDisplayElements { get; set; }
    public Configuration Configuration { get; set; }
    public ServerStubConfiguration ServerStubConfiguration { get; set; }

    public void Dispose()
    {
        Server?.Dispose();
    }
}