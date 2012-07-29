namespace ServiceBook
{
    using System;
    using ContainerConfigurators;

    public static class ContainerFactory
    {
        public static Container New(Action<ContainerConfigurator> configureCallback)
        {
            var configurator = new ContainerConfiguratorImpl();

            configureCallback(configurator);

            return configurator.Configure();
        }
    }
}