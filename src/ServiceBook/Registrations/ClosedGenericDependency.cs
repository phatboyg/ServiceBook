namespace ServiceBook.Registrations
{
    using System;
    using System.Linq;

    public class ClosedGenericDependency :
        Dependency
    {
        readonly Type[] _genericArguments;
        readonly Type _type;

        public ClosedGenericDependency(Type type)
        {
            if (!type.IsGenericType)
                throw new ArgumentException("Argument must be a generic type", "type");

            if (type.IsGenericTypeDefinition)
                throw new ArgumentException("Argument must be a closed generic type", "type");

            var genericArguments = _type.GetGenericArguments();
            if(genericArguments.Any(x => x.IsGenericParameter))
                throw new ArgumentException("Argument must not contain generic parameters", "type");

            _type = type;
            _genericArguments = genericArguments;
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