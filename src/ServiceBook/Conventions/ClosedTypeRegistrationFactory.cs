namespace ServiceBook.Conventions
{
    using System;
    using Registrations;

    public class ClosedTypeRegistrationFactory<T> :
        RegistrationFactory
    {
        readonly Func<Registration> _registrationFactory;

        public ClosedTypeRegistrationFactory(Func<Factory<T>> factoryFactory)
        {
            Registration registration = null;
            bool created = false;

            _registrationFactory = () =>
                {
                    if (created)
                        return registration;

                    var factory = factoryFactory();

                    registration = new ClosedTypeRegistration<T>(factory);
                    created = true;

                    return registration;
                };
        }

        public Registration Get()
        {
            return _registrationFactory();
        }
    }
}