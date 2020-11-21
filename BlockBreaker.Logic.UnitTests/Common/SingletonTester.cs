namespace BlockBreaker.Logic.UnitTests.Common
{
    using Kabatra.Common.Singleton;
    using System;

    public class SingletonTester<T> : IDisposable where T : SingletonBase<T>, new()
    {
        /// <summary>
        ///     Cleans up singleton object between unit tests.
        /// </summary>
        public void Dispose()
        {
            SingletonBase<T>.Reset();
        }
    }
}
