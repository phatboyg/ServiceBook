namespace ServiceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Internals.Caching;
    using Registrations;
    using Registrations.Algorithms;

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
            var catalog = new ContainerRegistrationCatalog(_registrationConvention, this);

            Registration result = catalog.GetRegistration(type);
            if (result == null)
                throw new ServiceBookException("The type or one or more of its dependencies could not be resolved");

            foreach (var registration in catalog.Registrations(type))
            {
                if (_types.HasValue(registration))
                    continue;

                _types.AddValue(registration);
            }

            return result;
        }

        class ContainerRegistrationCatalog :
            RegistrationCatalog
        {
            readonly RegistrationConvention _convention;
            readonly ConfigureContainer _configureContainer;
            readonly DependencyGraph<Type> _graph;
            readonly Cache<Type, Registration> _types;

            public ContainerRegistrationCatalog(RegistrationConvention convention,
                ConfigureContainer configureContainer)
            {
                _types = new DictionaryCache<Type, Registration>(x => x.Type);
                _graph = new DependencyGraph<Type>();

                _convention = convention;
                _configureContainer = configureContainer;
            }

            public Registration GetRegistration(Type type)
            {
                Registration existingRegistration;
                if(_configureContainer.TryGetRegistration(type, out existingRegistration))
                {
                    _types.AddValue(existingRegistration);

                    return existingRegistration;
                }

                IEnumerable<Registration> typeRegistrations = _convention.GetTypeRegistrations(this, type);
                foreach (Registration registration in typeRegistrations)
                {
                    _types[registration.Type] = registration;

                    if (type != registration.Type)
                        _graph.Add(type, registration.Type);
                }

                return _types[type];
            }

            public IEnumerable<Registration> Registrations(Type type)
            {
                return _graph.GetItemsInDependencyOrder(type).Select(x => _types[x]);
            }
        }
    }
}