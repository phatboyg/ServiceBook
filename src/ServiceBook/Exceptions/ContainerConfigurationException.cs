namespace ServiceBook
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using Configurators;

    [Serializable]
    public class ContainerConfigurationException :
        ServiceBookException
    {
        public ContainerConfigurationException()
        {
        }

        public ContainerConfigurationException(ConfigureResult result)
            : base(FormatMessage(result))
        {
        }

        public ContainerConfigurationException(ConfigureResult result, Exception innerException)
            : base(FormatMessage(result), innerException)
        {
        }

        protected ContainerConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Result = (ConfigureResult)info.GetValue("Result", typeof(ContainerConfigureResult));
        }

        public ConfigureResult Result { get; private set; }

        static string FormatMessage(ConfigureResult result)
        {
            return "There were errors configuring the container:" +
                   Environment.NewLine +
                   string.Join(Environment.NewLine, result.Results
                       .Select(x => string.Format("{0}: {1}", x.Key, x.Message)).ToArray());
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("Result", Result);
        }
    }
}