namespace ServiceBook
{
    using Configurators;

    public static class ConfiguratorExtensions
    {
        public static ConfigureResult Validate(this Configurator configurator)
        {
            var result = new ContainerConfigureResult(configurator.ValidateConfiguration());
            if (result.ContainsFailure)
                throw new ContainerConfigurationException(result);

            return result;
        }
    }
}