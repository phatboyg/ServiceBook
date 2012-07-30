namespace ServiceBook.Conventions
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Internals.Caching;
    using Registrations;

    public static class ConstructorRegistrationFactory
    {
        static readonly Cache<int, Type> _factoryCache = new ConcurrentCache<int, Type>();

        static ConstructorRegistrationFactory()
        {
            _factoryCache.Add(0, typeof(DefaultConstructorRegistrationFactory<>));
            _factoryCache.Add(1, typeof(ConstructorRegistrationFactory<,>));
            _factoryCache.Add(2, typeof(ConstructorRegistrationFactory<,,>));
        }

        public static RegistrationFactory Create(Type type, ConstructorInfo constructorInfo, Registration[] dependencies)
        {
            if (!_factoryCache.Has(dependencies.Length))
                throw new ArgumentException(
                    string.Format("Unable to create a factory for a constructor with {0} parameters",
                        dependencies.Length), "dependencies");

            Type factoryType = _factoryCache[dependencies.Length];

            Type[] genericTypes = Enumerable.Repeat(type, 1).Concat(dependencies.Select(x => x.Type)).ToArray();

            Type registrationType = factoryType.MakeGenericType(genericTypes);

            var factory = (RegistrationFactory)Activator.CreateInstance(registrationType, constructorInfo, dependencies);

            return factory;
        }
    }

    public class ConstructorRegistrationFactory<T, T1> :
        ClosedTypeRegistrationFactory<T>
    {
        public ConstructorRegistrationFactory(ConstructorInfo constructor, Registration[] registrations)
            : base(GetConstructorFactory(constructor, registrations))
        {
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, Registration[] registrations)
        {
            var arg1 = registrations[0] as Registration<T1>;
            if (arg1 == null)
                throw new ArgumentException(string.Format("The registration type was not valid: {0}",
                    registrations[0].Type));

            return () => new ConstructorFactory<T, T1>(constructor, arg1.Factory);
        }
    }

    public class ConstructorRegistrationFactory<T, T1, T2> :
        ClosedTypeRegistrationFactory<T>
    {
        public ConstructorRegistrationFactory(ConstructorInfo constructor, Registration[] registrations)
            : base(GetConstructorFactory(constructor, registrations))
        {
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, Registration[] registrations)
        {
            var arg1 = registrations[0] as Registration<T1>;
            if (arg1 == null)
                throw new ArgumentException(string.Format("The registration type was not valid: {0}",
                    registrations[0].Type));

            var arg2 = registrations[1] as Registration<T2>;
            if (arg2 == null)
                throw new ArgumentException(string.Format("The registration type was not valid: {0}",
                    registrations[1].Type));

            return () => new ConstructorFactory<T, T1, T2>(constructor, arg1.Factory, arg2.Factory);
        }
    }
}