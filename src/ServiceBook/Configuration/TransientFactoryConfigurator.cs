namespace ServiceBook
{
    public interface TransientFactoryConfigurator<T> :
        FactoryConfigurator<TransientFactoryConfigurator<T>>
    {
    }
}