namespace ServiceBook.Conventions
{
    using System.Reflection;
    using Factories;

    public class DefaultConstructorRegistrationFactory<T> :
        ClosedTypeRegistrationFactory<T>
    {
        public DefaultConstructorRegistrationFactory(ConstructorInfo constructor)
            : base(() => new DefaultConstructorFactory<T>(constructor))
        {
        }
    }
}