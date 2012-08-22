namespace ServiceBook.Registrations.RegistrationFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Creates a registration for a closed type (no open generic arguments) using the 
    /// supplied factory for the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClosedTypeRegistrationFactory<T> :
        RegistrationFactory,
        RegistrationFactoryCandidate
    {
        readonly RegistrationFactory[] _dependencies;
        readonly Func<Registration> _registrationFactory;

        /// <summary>
        /// Constructs the factory, only retrieving the factory when the
        /// registration is resolved.
        /// </summary>
        /// <param name="factoryFactory"></param>
        /// <param name="dependencies"> </param>
        public ClosedTypeRegistrationFactory(Func<Factory<T>> factoryFactory, params RegistrationFactory[] dependencies)
        {
            _dependencies = dependencies;
            Registration registration = null;
            bool created = false;

            _registrationFactory = () =>
                {
                    if (created)
                        return registration;

                    Factory<T> factory = factoryFactory();

                    registration = new ClosedTypeRegistration<T>(factory, _dependencies.Select(x => x.Get()).ToArray());
                    created = true;

                    return registration;
                };
        }

        public Type RegistrationType
        {
            get { return typeof(T); }
        }

        public IEnumerable<RegistrationFactoryCandidate> Candidates
        {
            get { yield return this; }
        }

        public Registration Get()
        {
            return _registrationFactory();
        }

        public IEnumerable<RegistrationFactory> Dependencies
        {
            get { return _dependencies; }
        }
    }
}