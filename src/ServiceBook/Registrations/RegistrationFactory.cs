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
        /// Returns the candidate factories for the registration, which may include candidates
        /// that cannot actually be created due to unrealized dependencies
        /// </summary>
        IEnumerable<RegistrationFactoryCandidate> Candidates { get; }

        /// <summary>
        /// Get the registration
        /// </summary>
        /// <returns></returns>
        Registration Get();
    }
}