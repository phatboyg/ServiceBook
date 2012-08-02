namespace ServiceBook
{
    using System;
    using Internals.Caching;
    using Registrations;

    public class ServiceBookContainer :
        Container,
        ConfigureContainer
    {
        readonly RegistrationConvention _registrationConvention;
        readonly Cache<Type, Registration> _types = new ConcurrentCache<Type, Registration>(value => value.Type);

        public ServiceBookContainer(RegistrationConvention registrationConvention)
        {
            _registrationConvention = registrationConvention;
        }

        public bool TryGetRegistration(Type type, out Registration registration)
        {
            registration = _types.GetValue(type, default(Registration));

            return registration != null;
        }

        public void AddRegistration(Registration registration)
        {
            _types.AddValue(registration);
        }

        public T Get<T>()
        {
            return ((Registration<T>)_types.Get(typeof(T), GetMissingTypeRegistration)).Get();
        }

        Registration GetMissingTypeRegistration(Type type)
        {
            RegistrationCatalog catalog = new ContainerRegistrationCatalog(_registrationConvention, this);

            RegistrationFactory registrationFactory = catalog.GetRegistration(type);
            if (registrationFactory == null)
                throw new ServiceBookException("The type or one or more of its dependencies could not be resolved");

            foreach (var registration in catalog.Registrations)
            {
                if (_types.Has(registration.RegistrationType))
                    continue;

                _types.AddValue(registration.Get());
            }

            return registrationFactory.Get();
        }
    }
}