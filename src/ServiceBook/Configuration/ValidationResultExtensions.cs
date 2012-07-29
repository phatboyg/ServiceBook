namespace ServiceBook
{
    using Configurators;

    public static class ValidateConfigurationResultExtensions
    {
        public static ValidateConfigurationResult Failure(this Configurator configurator, string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Failure, message);
        }

        public static ValidateConfigurationResult Failure(this Configurator configurator, string key, string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Failure, key, message);
        }

        public static ValidateConfigurationResult Failure(this Configurator configurator, string key, string value,
            string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Failure, key, value, message);
        }

        public static ValidateConfigurationResult Warning(this Configurator configurator, string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Warning, message);
        }

        public static ValidateConfigurationResult Warning(this Configurator configurator, string key, string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Warning, key, message);
        }

        public static ValidateConfigurationResult Warning(this Configurator configurator, string key, string value,
            string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Warning, key, value, message);
        }

        public static ValidateConfigurationResult Success(this Configurator configurator, string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Success, message);
        }

        public static ValidateConfigurationResult Success(this Configurator configurator, string key, string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Success, key, message);
        }

        public static ValidateConfigurationResult Success(this Configurator configurator, string key, string value,
            string message)
        {
            return new ValidateConfigurationResultImpl(ValidateConfigurationDisposition.Success, key, value, message);
        }

        public static ValidateConfigurationResult WithParentKey(this ValidateConfigurationResult result,
            string parentKey)
        {
            //string key = result.Key.Contains(".") ? result.Key.Substring(result.Key.IndexOf('.')) : "";

            string key = parentKey + "." + result.Key;

            return new ValidateConfigurationResultImpl(result.Disposition, key, result.Value, result.Message);
        }
    }
}