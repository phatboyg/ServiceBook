namespace ServiceBook
{
    using System;
    using Registrations;

    /// <summary>
    /// Used by external configuration objects to configure the container contents
    /// </summary>
    public interface ConfigureContainer
    {
        /// <summary>
        /// Attempts to retrieve an existing registration from the container
        /// </summary>
        /// <param name="type">The registration type</param>
        /// <param name="registration">The registration if it exists</param>
        /// <returns>True if the registration exists, otherwise false</returns>
        bool TryGetRegistration(Type type, out Registration registration);

        /// <summary>
        /// Add a new registration to the container
        /// </summary>
        /// <param name="registration"></param>
        void AddRegistration(Registration registration);
    }
}