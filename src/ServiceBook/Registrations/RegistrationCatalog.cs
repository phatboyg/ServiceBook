namespace ServiceBook.Registrations
{
    using System;

    public interface RegistrationCatalog
    {
        Registration GetRegistration(Type type);
    }
}