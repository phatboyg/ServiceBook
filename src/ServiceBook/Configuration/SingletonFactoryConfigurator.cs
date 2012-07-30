namespace ServiceBook
{
    public interface SingletonFactoryConfigurator<T> :
        FactoryConfigurator<SingletonFactoryConfigurator<T>>
    {
         
    }
}