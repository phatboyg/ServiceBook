namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Registration Factory is contains the details necessary to create a Registration,
    /// which can be added to the container.
    /// </summary>
    public interface RegistrationFactory
    {
        /// <summary>
        /// The factory type that is registered by this registration
        /// </summary>
        Type RegistrationType { get; }

        /// <summary>
        /// The types which the factory type is dependent upon
        /// </summary>
        IEnumerable<Type> DependencyTypes { get; }

        /// <summary>
        /// Get the registration
        /// </summary>
        /// <returns></returns>
        Registration Get();
    }
}