namespace ServiceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Internals.Caching;
    using Internals.Extensions;
    using Registrations;
    using Registrations.Algorithms;

    public class ContainerRegistrationCatalog :
        RegistrationCatalog
    {
        readonly ConfigureContainer _configureContainer;
        readonly RegistrationConvention _convention;
        readonly DependencyGraph<Type> _graph;
        readonly Cache<Type, CatalogRegistration> _types;


        public ContainerRegistrationCatalog(RegistrationConvention convention, ConfigureContainer configureContainer)
        {
            _types = new DictionaryCache<Type, CatalogRegistration>(x => x.Registration.RegistrationType);
            _graph = new DependencyGraph<Type>();

            _convention = convention;
            _configureContainer = configureContainer;
        }

        public void AddRegistration(RegistrationFactory registration)
        {
            if (_types.Has(registration.RegistrationType))
            {
                CatalogRegistration catalogRegistration = _types[registration.RegistrationType];
                if (catalogRegistration.IsExisting)
                    throw new ServiceBookException("An existing registration already exists for "
                                                   + registration.RegistrationType.GetTypeName());

                if (catalogRegistration.IsExplicit)
                    throw new ServiceBookException("An explicit registration already exists for "
                                                   + registration.RegistrationType.GetTypeName());

                catalogRegistration.Registration = registration;
                return;
            }

            _types.AddValue(new CatalogRegistration {Registration = registration, IsExplicit = true});
        }

        public RegistrationFactory GetRegistration(Type type)
        {
            if(_types.Has(type))
                return _types[type].Registration;

            Registration existingRegistration;
            if (_configureContainer.TryGetRegistration(type, out existingRegistration))
            {
                var existingRegistrationFactory = new ExistingRegistrationFactory(existingRegistration);

                _types.AddValue(new CatalogRegistration {Registration = existingRegistrationFactory, IsExisting = true});

                return existingRegistrationFactory;
            }

            IEnumerable<RegistrationFactory> typeRegistrations = _convention.GetTypeRegistrations(this, type);
            foreach (RegistrationFactory registration in typeRegistrations)
            {
                if (!_types.Has(registration.RegistrationType))
                    _types.AddValue(new CatalogRegistration {Registration = registration});

                if (type != registration.RegistrationType)
                    _graph.Add(type, registration.RegistrationType);
            }

            return _types[type].Registration;
        }

        IEnumerable<RegistrationFactory> RegistrationCatalog.Registrations
        {
            get
            {
                return _graph.GetItemsInDependencyOrder()
                    .Select(x => _types[x])
                    .Where(x => !x.IsExisting)
                    .Select(x => x.Registration);
            }
        }

        class CatalogRegistration
        {
            public RegistrationFactory Registration { get; set; }
            public bool IsExisting { get; set; }
            public bool IsExplicit { get; set; }
        }
    }
}