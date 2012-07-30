namespace ServiceBook.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Internals.Extensions;
    using Registrations;

    public class ConcreteTypeRegistrationConvention :
        RegistrationConvention
    {
        public IEnumerable<Registration> GetTypeRegistrations(Type type)
        {
            if (type.IsConcreteType())
            {
                Registration[] defaultConstructor = GetDefaultConstructor(type).ToArray();
                if (defaultConstructor.Any())
                    return defaultConstructor;
            }

            return Enumerable.Empty<Registration>();
        }

        IEnumerable<Registration> GetDefaultConstructor(Type type)
        {
            ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
            if (constructorInfo != null)
            {
                Type registrationType = typeof(DefaultConstructorRegistrationFactory<>).MakeGenericType(type);

                var factory = (RegistrationFactory)Activator.CreateInstance(registrationType, constructorInfo);

                yield return factory.Get();
            }
        }
    }
}