namespace ServiceBook.FactoryConfigurators
{
    using System.Collections.Generic;
    using BuilderConfigurators;
    using Builders;
    using Configurators;
    using Internals.Extensions;

    public class SingletonFactoryConfiguratorImpl<T> :
        FactoryConfiguratorImpl<SingletonFactoryConfigurator<T>>,
        SingletonFactoryConfigurator<T>,
        ContainerBuilderConfigurator
    {
        public override IEnumerable<ValidateConfigurationResult> ValidateConfiguration()
        {
            yield return this.Failure(typeof(T).GetTypeName(), "The singleton factory is not working yet");
        }

        public ContainerBuilder Configure(ContainerBuilder builder)
        {
            return builder;
        }
    }
}