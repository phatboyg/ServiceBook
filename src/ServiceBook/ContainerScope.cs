namespace ServiceBook
{
    using System;

    /// <summary>
    /// ContainerScope is used to keep track of objects that are retrieved, so that they can be
    /// released once the scope is closed. A scope also allows lifecycle to be modified such that
    /// scope singletons can be created (for keeping track of unit of work transactions and other
    /// things)
    /// </summary>
    public interface ContainerScope :
        Container,
        IDisposable
    {

        /// <summary>
        /// Release all objects managed by the container scope
        /// </summary>
        void Release();
    }
}