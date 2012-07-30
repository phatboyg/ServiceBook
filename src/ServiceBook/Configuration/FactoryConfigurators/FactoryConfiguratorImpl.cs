namespace ServiceBook.FactoryConfigurators
{
    using System.Collections.Generic;
    using Configurators;

    public class FactoryConfiguratorImpl<TInterface>
        where TInterface : class, FactoryConfigurator<TInterface>
    {
        public virtual IEnumerable<ValidateConfigurationResult> ValidateConfiguration()
        {
            yield break;
        }

        public virtual TInterface SomeFlagForAllFactories()
        {
            return this as TInterface;
        }
    }
}