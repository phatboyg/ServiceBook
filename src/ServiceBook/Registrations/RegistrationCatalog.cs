namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Supports type registration through both explicit (Add) and implicit (Get) methods.
    /// Explicit registrations replace implicit registrations before the catalog is applied
    /// to the container
    /// </summary>
    public interface RegistrationCatalog
    {
        /// <summary>
        /// Add an explicit registration to the catalog
        /// </summary>
        /// <param name="registration"></param>
        void AddRegistration(RegistrationFactory registration);

        /// <summary>
        /// Returns the registration for a type if it can be retrieved. If the type cannot be retrieved,
        /// an exception is thrown.
        /// </summary>
        /// <param name="type">The object type being requested</param>
        /// <returns>The registration if it exists, otherwise null.</returns>
        RegistrationFactory GetRegistration(Type type);

        /// <summary>
        /// Returns a list of registrations that should be added to the container. Existing registrations
        /// are not included
        /// </summary>
        IEnumerable<RegistrationFactory> Registrations { get; }
    }
}