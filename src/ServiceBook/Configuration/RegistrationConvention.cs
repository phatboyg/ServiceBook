namespace ServiceBook
{
    using System;
    using System.Collections.Generic;
    using Registrations;

    public interface RegistrationConvention
    {
        IEnumerable<Registration> GetTypeRegistrations(Type type);
    }
}