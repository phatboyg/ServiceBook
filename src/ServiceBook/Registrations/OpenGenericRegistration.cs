namespace ServiceBook.Registrations
{
    using System;
    using Internals.Extensions;

    public class OpenGenericRegistration
    {
        readonly Type[] _arguments;
        readonly Type _genericType;

        public OpenGenericRegistration(Type type)
        {
            if (!type.IsOpenGeneric())
                throw new ArgumentException("A generic type must be specified", "type");

            _genericType = type.GetGenericTypeDefinition();
            _arguments = type.GetGenericArguments();
        }

        public Type GenericType
        {
            get { return _genericType; }
        }

        public Type[] Arguments
        {
            get { return _arguments; }
        }
    }
}
