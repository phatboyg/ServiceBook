namespace ServiceBook.ReleaseHandlers
{
    using System;

    public class DisposeReleaseHandler<T> :
        ReleaseHandler<T>
        where T : IDisposable
    {
        public void OnRelease(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj", "Should never receive a null object on release");

            var instance = (T)obj;

            using (instance)
            {
            }
        }
    }
}