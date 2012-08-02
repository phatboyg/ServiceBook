namespace ServiceBook.Builders
{
    public interface ContainerBuilder
    {
        Container Build();

        void AddRegistrationConvention(RegistrationConvention convention);

    }
}