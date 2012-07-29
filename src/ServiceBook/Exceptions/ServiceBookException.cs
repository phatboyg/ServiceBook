namespace ServiceBook
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ServiceBookException :
        Exception
    {
        public ServiceBookException()
        {
        }

        public ServiceBookException(string message)
            : base(message)
        {
        }

        public ServiceBookException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ServiceBookException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}