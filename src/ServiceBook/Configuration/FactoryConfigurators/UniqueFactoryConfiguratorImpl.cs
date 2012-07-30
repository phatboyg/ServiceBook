namespace ServiceBook.FactoryConfigurators
{
    using System.Collections.Generic;
    using BuilderConfigurators;
    using Builders;
    using Configurators;
    using Internals.Extensions;

    public class UniqueFactoryConfiguratorImpl<T> :
        FactoryConfiguratorImpl<UniqueFactoryConfigurator<T>>,
        UniqueFactoryConfigurator<T>,
        ContainerBuilderConfigurator
    {
        public override IEnumerable<ValidateConfigurationResult> ValidateConfiguration()
        {
            yield return this.Failure(typeof(T).GetTypeName(), "The unique factory is not working yet");
        }

        public ContainerBuilder Configure(ContainerBuilder builder)
        {
            return builder;
        }
    }
}