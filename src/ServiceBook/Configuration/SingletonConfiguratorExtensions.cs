namespace ServiceBook
{
    using FactoryConfigurators;

    public static class SingletonConfiguratorExtensions
    {
        public static SingletonFactoryConfigurator<T> Singleton<T>(this ContainerConfigurator configurator)
        {
            var factoryConfigurator = new SingletonFactoryConfiguratorImpl<T>();

            configurator.AddConfigurator(factoryConfigurator);

            return factoryConfigurator;
        }
    }
}