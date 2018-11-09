using System;

namespace MarsRover.Core
{
    // Similar to https://github.com/HeadspringLabs/HeadspringTime/blob/master/SystemClock.cs
    public static class SystemClock
    {
        private static Func<DateTime> now = nowDefault;
        private static Func<DateTime> utcNow = utcNowDefault;

        public static DateTime Now
        {
            get { return now(); }
        }

        public static DateTime UtcNow
        {
            get { return utcNow(); }
        }

        public static IDisposable StubNow(DateTime dateTime)
        {
            if (now != nowDefault)
                throw new InvalidOperationException("Previous SystemClock.StubNow has not been disposed!");

            now = () => dateTime;
            return Disposable.Create(() => now = nowDefault);
        }

        public static IDisposable StubUtcNow(DateTime dateTime)
        {
            if (utcNow != utcNowDefault)
                throw new InvalidOperationException("Previous SystemClock.StubUtcNow has not been disposed!");

            utcNow = () => dateTime;
            return Disposable.Create(() => utcNow = utcNowDefault);
        }

        private static DateTime nowDefault()
        {
            return DateTime.Now;
        }

        private static DateTime utcNowDefault()
        {
            return DateTime.UtcNow;
        }
    }
}
