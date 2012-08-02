namespace ServiceBook.Registrations
{
    using System;

    public class ClosedGenericRegistration
    {
        readonly Type[] _argumentTypes;
        readonly Type _genericType;
        readonly Type _type;

        public ClosedGenericRegistration(Type type)
        {
            if (type.IsGenericTypeDefinition)
                throw new ArgumentException("A closed type must be specified", "type");

            _type = type;

            _argumentTypes = type.GetGenericArguments();
            _genericType = type.GetGenericTypeDefinition();
        }

        public Type GenericType
        {
            get { return _genericType; }
        }

        public Type Type
        {
            get { return _type; }
        }

        public Type[] ArgumentTypes
        {
            get { return _argumentTypes; }
        }
    }
}