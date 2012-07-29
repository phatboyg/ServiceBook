namespace ServiceBook.Configurators
{
    using System.Collections.Generic;

    public interface Configurator
    {
        IEnumerable<ValidateConfigurationResult> ValidateConfiguration();
    }
}