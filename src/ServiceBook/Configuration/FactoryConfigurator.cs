namespace ServiceBook
{
    public interface FactoryConfigurator<out TInterface>
        where TInterface : class
    {
        TInterface SomeFlagForAllFactories();
    }
}