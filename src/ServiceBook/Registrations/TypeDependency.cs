namespace ServiceBook.Registrations
{
    using System;

    public class TypeDependency :
        Dependency
    {
        readonly Type[] _genericArguments;
        readonly Type _type;

        public TypeDependency(Type type)
        {
            if (type.IsGenericType)
                throw new ArgumentException("Argument must not be a generic type", "type");

            _type = type;
            _genericArguments = Type.EmptyTypes;
        }

        public Type DependencyType
        {
            get { return _type; }
        }

        public Type[] GenericArguments
        {
            get { return _genericArguments; }
        }
    }
}