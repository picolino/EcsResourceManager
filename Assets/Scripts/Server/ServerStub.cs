#region Usings

using System;
using System.Timers;

#endregion

namespace Server
{
    public class ServerStub : IServer
    {
        private readonly ServerStubConfiguration configuration;
        private readonly Random random;
        private readonly int[] resourceIds;

        private readonly Timer timer;

        public ServerStub(ServerStubConfiguration configuration, Random random, int[] resourceIds)
        {
            this.configuration = configuration;
            this.random = random;
            this.resourceIds = resourceIds;

            timer = new Timer();
            SetNewTimerInterval();
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
        }

        public event Action<int, double> ResourceChangedEvent;

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();

            var selectedResourceUid = resourceIds[random.Next(resourceIds.Length)];
            ResourceChangedEvent?.Invoke(selectedResourceUid, random.NextDouble() * random.Next(configuration.amountMin, configuration.amountMax));

            SetNewTimerInterval();
            timer.Start();
        }

        private void SetNewTimerInterval()
        {
            var newInterval = random.NextDouble() * random.Next(configuration.intervalMin, configuration.intervalMax);
            timer.Interval = newInterval;
        }

        public void Dispose()
        {
            timer.Elapsed -= TimerOnElapsed;
            timer?.Dispose();
        }
    }
}