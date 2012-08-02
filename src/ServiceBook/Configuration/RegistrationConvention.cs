namespace ServiceBook
{
    using System;
    using System.Collections.Generic;
    using Registrations;

    public interface RegistrationConvention
    {
        IEnumerable<RegistrationFactory> GetTypeRegistrations(RegistrationCatalog catalog, Type type);
    }
}