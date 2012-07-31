namespace ServiceBook.Conventions
{
    using System;
    using Registrations;

    /// <summary>
    /// Creates a registration for a closed type (no open generic arguments) using the 
    /// supplied factory for the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClosedTypeRegistrationFactory<T> :
        RegistrationFactory
    {
        readonly Func<Registration> _registrationFactory;

        /// <summary>
        /// Constructs the factory, only retrieving the factory when the
        /// registration is resolved.
        /// </summary>
        /// <param name="factoryFactory"></param>
        public ClosedTypeRegistrationFactory(Func<Factory<T>> factoryFactory)
        {
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

        public Registration Get()
        {
            return _registrationFactory();
        }

        protected static Factory<TFactory> GetFactory<TFactory>(Registration registration)
        {
            var factoryRegistration = registration as Registration<TFactory>;
            if (factoryRegistration == null)
                throw new ArgumentException(string.Format("The registration type was not valid: {0}",
                    registration.Type));

            return factoryRegistration.Factory;
        }
    }
}