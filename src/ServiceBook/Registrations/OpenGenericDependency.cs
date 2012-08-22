namespace ServiceBook.Registrations
{
    using System;

    public class OpenGenericDependency :
        Dependency
    {
        readonly Type[] _genericArguments;
        readonly Type _type;

        public OpenGenericDependency(Type type, Type[] genericArguments)
        {
            if (!type.IsGenericType)
                throw new ArgumentException("Type must be a generic type definition", "type");

            _type = type.IsGenericTypeDefinition
                        ? type
                        : type.GetGenericTypeDefinition();

            Type[] arguments = _type.GetGenericArguments();

            _genericArguments = new Type[arguments.Length];
            int i = 0;
            for (; i < arguments.Length && i < genericArguments.Length; i++)
            {
                _genericArguments[i] = genericArguments[i].MeetsGenericParameterConstraints(arguments[i])
                                           ? genericArguments[i]
                                           : arguments[i];
            }
            for (; i < arguments.Length; i++)
            {
                _genericArguments[i] = arguments[i];
            }
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