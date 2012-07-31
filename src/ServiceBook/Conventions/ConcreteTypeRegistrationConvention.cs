namespace ServiceBook.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Internals.Extensions;
    using Registrations;
    using Registrations.RegistrationFactories;

    public class ConcreteTypeRegistrationConvention :
        RegistrationConvention
    {
        public IEnumerable<Registration> GetTypeRegistrations(RegistrationCatalog catalog, Type type)
        {
            if (type.IsConcreteType())
            {
                Registration[] defaultConstructor = GetDefaultConstructor(type).ToArray();
                if (defaultConstructor.Any())
                    return defaultConstructor;

                Registration[] greediestConstructor = GetGreediestConstructor(catalog, type).ToArray();
                if (greediestConstructor.Any())
                    return greediestConstructor;
            }

            return Enumerable.Empty<Registration>();
        }

        IEnumerable<Registration> GetDefaultConstructor(Type type)
        {
            ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
            if (constructorInfo != null)
            {
                RegistrationFactory factory = ConstructorRegistrationFactory.Create(type, constructorInfo);
                yield return factory.Get();
            }
        }

        IEnumerable<Registration> GetGreediestConstructor(RegistrationCatalog catalog, Type type)
        {
            IOrderedEnumerable<ConstructorInfo> candidates = type.GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length);

            foreach (ConstructorInfo candidate in candidates)
            {
                Type[] dependencies = candidate.GetParameters().Select(x => x.ParameterType).ToArray();

                Registration[] registrations =
                    GetConstructorRegistrations(catalog, type, candidate, dependencies).ToArray();

                if (registrations.Any())
                    return registrations;
            }

            return Enumerable.Empty<Registration>();
        }

        IEnumerable<Registration> GetConstructorRegistrations(RegistrationCatalog catalog, Type type,
            ConstructorInfo constructorInfo, IEnumerable<Type> dependencies)
        {
            ParameterInfo[] parameters = constructorInfo.GetParameters();

            Registration[] arguments = dependencies
                .Select((x, index) => catalog.GetRegistration(parameters[index].ParameterType)).ToArray();

            if (parameters.Length == arguments.Length)
            {
                RegistrationFactory factory = ConstructorRegistrationFactory.Create(type, constructorInfo, arguments);

                return arguments.Concat(Enumerable.Repeat(factory.Get(), 1));
            }

            return Enumerable.Empty<Registration>();
        }
    }
}