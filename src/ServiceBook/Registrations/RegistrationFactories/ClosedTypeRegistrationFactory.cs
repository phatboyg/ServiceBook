namespace ServiceBook.Registrations.RegistrationFactories
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Creates a registration for a closed type (no open generic arguments) using the 
    /// supplied factory for the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClosedTypeRegistrationFactory<T> :
        RegistrationFactory
    {
        readonly IEnumerable<Type> _dependencyTypes;
        readonly Func<Registration> _registrationFactory;

        /// <summary>
        /// Constructs the factory, only retrieving the factory when the
        /// registration is resolved.
        /// </summary>
        /// <param name="factoryFactory"></param>
        /// <param name="dependencyTypes"> </param>
        public ClosedTypeRegistrationFactory(Func<Factory<T>> factoryFactory, IEnumerable<Type> dependencyTypes)
        {
            _dependencyTypes = dependencyTypes;
            Registration registration = null;
            bool created = false;

            _registrationFactory = () =>
                {
                    if (created)
                        return registration;

                    Factory<T> factory = factoryFactory();

                    registration = new ClosedTypeRegistration<T>(factory);
                    created = true;

                    return registration;
                };
        }

        public Type RegistrationType
        {
            get { return typeof(T); }
        }

        public IEnumerable<Type> DependencyTypes
        {
            get { return _dependencyTypes; }
        }

        public Registration Get()
        {
            return _registrationFactory();
        }
    }
}