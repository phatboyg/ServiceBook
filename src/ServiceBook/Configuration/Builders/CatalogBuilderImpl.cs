namespace ServiceBook.Builders
{
    using System;
    using System.Collections.Generic;
    using Internals.Caching;
    using Registrations;

    public class CatalogBuilderImpl :
        CatalogBuilder
    {
        readonly Cache<Type, IList<RegistrationFactory>> _types;

        public CatalogBuilderImpl()
        {
            _types = new DictionaryCache<Type, IList<RegistrationFactory>>(type => new List<RegistrationFactory>());
        }

        public void AddRegistrationFactory(RegistrationFactory registrationFactory)
        {
            _types[registrationFactory.RegistrationType].Add(registrationFactory);
        }

        public void Build()
        {
        }
    }
}