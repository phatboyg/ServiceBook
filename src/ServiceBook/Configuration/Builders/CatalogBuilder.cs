namespace ServiceBook.Builders
{
    using Registrations;

    /// <summary>
    /// Used to build a catalog given the types added and discovered
    /// </summary>
    public interface CatalogBuilder
    {
        void AddRegistrationFactory(RegistrationFactory registrationFactory);
        void Build();
    }
}