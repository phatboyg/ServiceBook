namespace ServiceBook.FactoryConfigurators
{
    using System.Collections.Generic;
    using BuilderConfigurators;
    using Builders;
    using Configurators;

    public class TransientFactoryConfiguratorImpl<T> :
        FactoryConfiguratorImpl<TransientFactoryConfigurator<T>>,
        TransientFactoryConfigurator<T>,
        ContainerBuilderConfigurator
    {
        public override IEnumerable<ValidateConfigurationResult> ValidateConfiguration()
        {
            yield break;
        }

        public ContainerBuilder Configure(ContainerBuilder builder)
        {
            return builder;
        }
    }
}