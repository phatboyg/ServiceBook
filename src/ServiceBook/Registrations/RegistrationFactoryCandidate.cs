namespace ServiceBook.Registrations
{
    using System.Collections.Generic;

    /// <summary>
    /// A candidate factory for the registration factory that has a list of dependencies (some of
    /// which may not be realized).
    /// </summary>
    public interface RegistrationFactoryCandidate
    {
        /// <summary>
        /// The registration factories that this registration factory is dependent upon
        /// </summary>
        IEnumerable<RegistrationFactory> Dependencies { get; }

        /// <summary>
        /// Get the registration
        /// </summary>
        /// <returns></returns>
        Registration Get();
    }
}