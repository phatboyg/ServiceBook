namespace ServiceBook
{
    public interface UniqueFactoryConfigurator<T> :
        FactoryConfigurator<UniqueFactoryConfigurator<T>>
    {
    }
}