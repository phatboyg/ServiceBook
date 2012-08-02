namespace ServiceBook.Registrations
{
    using System;

    public static class GenericTypeExtensions
    {
        public static bool MeetsGenericParameterConstraints(this Type type, Type genericArgument)
        {
            if (!genericArgument.IsGenericParameter)
                throw new ArgumentException("The argument must be a generic parameter.", "genericArgument");

            Type[] constraints = genericArgument.GetGenericParameterConstraints();
            for (int i = 0; i < constraints.Length; i++)
            {
                if (!constraints[i].IsAssignableFrom(type))
                    return false;
            }

            return true;
        }
    }
}