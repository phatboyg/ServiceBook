namespace ServiceBook.Registrations
{
    using System;
    using System.Linq;

    public static class DependencyExtensions
    {
        public static Dependency GetDependency(this Type type, params Type[] genericArguments)
        {
            if (type.IsGenericType)
            {
                if (type.IsGenericTypeDefinition || type.GetGenericArguments().Any(x => x.IsGenericParameter))
                    return new OpenGenericDependency(type, genericArguments);

                return new ClosedGenericDependency(type);
            }

            return new TypeDependency(type);
        }
    }
}