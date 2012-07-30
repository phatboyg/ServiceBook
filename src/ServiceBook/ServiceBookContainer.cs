namespace ServiceBook
{
    using System;
    using Internals.Caching;
    using Registrations;

    public class ServiceBookContainer :
        Container,
        RegistrationCatalog
    {
        readonly RegistrationConvention _registrationConvention;
        readonly Cache<Type, Registration> _types = new ConcurrentCache<Type, Registration>(value => value.Type);

        public ServiceBookContainer(RegistrationConvention registrationConvention)
        {
            _registrationConvention = registrationConvention;
        }

        public T Get<T>()
        {
            return ((Registration<T>)_types.Get(typeof(T), GetMissingTypeRegistration)).Get();
        }

        Registration GetMissingTypeRegistration(Type type)
        {
            Registration result = null;
            foreach (Registration typeRegistration in _registrationConvention.GetTypeRegistrations(this, type))
            {
                if (typeRegistration.Type == type)
                    result = typeRegistration;
                else
                    _types.AddValue(typeRegistration);
            }

            if (result == null)
                throw new ServiceBookException("Unable to find type");

            return result;
        }

        public Registration GetRegistration(Type type)
        {
            return _types.Get(type, GetMissingTypeRegistration);
        }
    }
}