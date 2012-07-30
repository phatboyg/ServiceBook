namespace ServiceBook
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using ContainerConfigurators;

    public static class ContainerFactory
    {
        public static Container New(Action<ContainerConfigurator> configureCallback)
        {
            var configurator = new ContainerConfiguratorImpl();

            configureCallback(configurator);

            ConfigureResult configureResult = configurator.Validate();

            string messages = string.Join(Environment.NewLine,
#if !NET35
                configureResult.Results.Select(x => string.Format("{0}: {1}", x.Key, x.Message)));
#else
                configureResult.Results.Select(x => string.Format("{0}: {1}", x.Key, x.Message).ToArray()));
#endif

            if (messages.Length > 0)
            {
                Trace.WriteLine("Container Configuration Messages:");
                Trace.WriteLine(messages);
            }

            return configurator.Create();
        }
    }
}