namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    public interface TypeRegistrationResolver
    {
        IEnumerable<Registration> Resolve(Type type);
    }
}