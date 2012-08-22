namespace ServiceBook.Registrations
{
    using System;

    /// <summary>
    /// A type dependency can be a concrete type, an interface, or an open or closed generic type
    /// </summary>
    public interface Dependency
    {
        /// <summary>
        /// The dependency type is either a concrete type, an interface, or an open generic type
        /// </summary>
        Type DependencyType { get; }

        /// <summary>
        /// If the dependency type is an open generic, these are the generic arguments
        /// </summary>
        Type[] GenericArguments { get; }
    }
}