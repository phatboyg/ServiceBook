namespace ServiceBook.Conventions
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Factories;
    using Internals.Caching;
    using Registrations;

    public static class ConstructorRegistrationFactory
    {
        static readonly Cache<int, Type> _factoryCache = new ConcurrentCache<int, Type>();

        static ConstructorRegistrationFactory()
        {
            _factoryCache.Add(0, typeof(ConstructorRegistrationFactory<>));
            _factoryCache.Add(1, typeof(ConstructorRegistrationFactory<,>));
            _factoryCache.Add(2, typeof(ConstructorRegistrationFactory<,,>));
            _factoryCache.Add(3, typeof(ConstructorRegistrationFactory<,,,>));
            _factoryCache.Add(4, typeof(ConstructorRegistrationFactory<,,,,>));
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

    public class ConstructorRegistrationFactory<T> :
        ClosedTypeRegistrationFactory<T>
    {
        public ConstructorRegistrationFactory(ConstructorInfo constructor)
            : base(() => new ConstructorFactory<T>(constructor))
        {
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
            return () =>
                {
                    Factory<T1> factory1 = GetFactory<T1>(registrations[0]);

                    var factory = new ConstructorFactory<T, T1>(constructor);

                    return new CurryFactory<T, T1>(factory, factory1);
                };
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
            return () =>
                {
                    Factory<T1> factory1 = GetFactory<T1>(registrations[0]);
                    Factory<T2> factory2 = GetFactory<T2>(registrations[1]);

                    var factory = new ConstructorFactory<T, T1, T2>(constructor);

                    var curryFactory2 = new CurryFactory<T, T1, T2>(factory, factory2);

                    return new CurryFactory<T, T1>(curryFactory2, factory1);
                };
        }
    }

    public class ConstructorRegistrationFactory<T, T1, T2, T3> :
        ClosedTypeRegistrationFactory<T>
    {
        public ConstructorRegistrationFactory(ConstructorInfo constructor, Registration[] registrations)
            : base(GetConstructorFactory(constructor, registrations))
        {
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, Registration[] registrations)
        {
            return () =>
                {
                    Factory<T1> factory1 = GetFactory<T1>(registrations[0]);
                    Factory<T2> factory2 = GetFactory<T2>(registrations[1]);
                    Factory<T3> factory3 = GetFactory<T3>(registrations[2]);

                    var factory = new ConstructorFactory<T, T1, T2, T3>(constructor);

                    var curryFactory3 = new CurryFactory<T, T1, T2, T3>(factory, factory3);
                    var curryFactory2 = new CurryFactory<T, T1, T2>(curryFactory3, factory2);

                    return new CurryFactory<T, T1>(curryFactory2, factory1);
                };
        }
    }

    public class ConstructorRegistrationFactory<T, T1, T2, T3, T4> :
        ClosedTypeRegistrationFactory<T>
    {
        public ConstructorRegistrationFactory(ConstructorInfo constructor, Registration[] registrations)
            : base(GetConstructorFactory(constructor, registrations))
        {
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, Registration[] registrations)
        {
            return () =>
                {
                    Factory<T1> factory1 = GetFactory<T1>(registrations[0]);
                    Factory<T2> factory2 = GetFactory<T2>(registrations[1]);
                    Factory<T3> factory3 = GetFactory<T3>(registrations[2]);
                    Factory<T4> factory4 = GetFactory<T4>(registrations[3]);

                    var factory = new ConstructorFactory<T, T1, T2, T3, T4>(constructor);

                    var curryFactory4 = new CurryFactory<T, T1, T2, T3, T4>(factory, factory4);
                    var curryFactory3 = new CurryFactory<T, T1, T2, T3>(curryFactory4, factory3);
                    var curryFactory2 = new CurryFactory<T, T1, T2>(curryFactory3, factory2);

                    return new CurryFactory<T, T1>(curryFactory2, factory1);
                };
        }
    }
}