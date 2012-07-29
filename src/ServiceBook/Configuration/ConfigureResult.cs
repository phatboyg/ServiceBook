namespace ServiceBook
{
    using System.Collections.Generic;
    using Configurators;

    public interface ConfigureResult
    {
        IEnumerable<ValidateConfigurationResult> Results { get; }
    }
}