using System;

namespace MarsRover.Core
{
    public static class Disposable
    {
        public static IDisposable Create(Action onDispose)
        {
            return new AnonymousDisposable(onDispose);
        }

        public class AnonymousDisposable : IDisposable
        {
            private readonly Action onDispose;

            public AnonymousDisposable(Action onDispose)
            {
                this.onDispose = onDispose;
            }

            public void Dispose()
            {
                if (onDispose != null)
                    onDispose();
            }
        }
    }
}
