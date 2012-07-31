namespace ServiceBook.Registrations.RegistrationFactories
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
            _factoryCache.Add(5, typeof(ConstructorRegistrationFactory<,,,,,>));
            _factoryCache.Add(6, typeof(ConstructorRegistrationFactory<,,,,,,>));
            _factoryCache.Add(7, typeof(ConstructorRegistrationFactory<,,,,,,,>));
            _factoryCache.Add(8, typeof(ConstructorRegistrationFactory<,,,,,,,,>));
            _factoryCache.Add(9, typeof(ConstructorRegistrationFactory<,,,,,,,,,>));
            _factoryCache.Add(10, typeof(ConstructorRegistrationFactory<,,,,,,,,,,>));
            _factoryCache.Add(11, typeof(ConstructorRegistrationFactory<,,,,,,,,,,,>));
            _factoryCache.Add(12, typeof(ConstructorRegistrationFactory<,,,,,,,,,,,,>));
            _factoryCache.Add(13, typeof(ConstructorRegistrationFactory<,,,,,,,,,,,,,>));
            _factoryCache.Add(14, typeof(ConstructorRegistrationFactory<,,,,,,,,,,,,,,>));
            _factoryCache.Add(15, typeof(ConstructorRegistrationFactory<,,,,,,,,,,,,,,,>));
        }

        public static RegistrationFactory Create(Type type, ConstructorInfo constructorInfo, params Registration[] dependencies)
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
        public ConstructorRegistrationFactory(ConstructorInfo constructor, Registration[] registrations)
            : base(GetConstructorFactory(constructor, registrations))
        {
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, Registration[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T>(constructor);

                    return factory;
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1> :
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
                    var factory = new ConstructorFactory<T,T1>(constructor);

                    return factory.ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2> :
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
                    var factory = new ConstructorFactory<T,T1,T2>(constructor);

                    return factory.ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3>(constructor);

                    return factory.ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4>(constructor);

                    return factory.ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5>(constructor);

                    return factory.ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6>(constructor);

                    return factory.ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7>(constructor);

                    return factory.ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8>(constructor);

                    return factory.ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>(constructor);

                    return factory.ApplyPartial(registrations[8])
                                  .ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>(constructor);

                    return factory.ApplyPartial(registrations[9])
                                  .ApplyPartial(registrations[8])
                                  .ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>(constructor);

                    return factory.ApplyPartial(registrations[10])
                                  .ApplyPartial(registrations[9])
                                  .ApplyPartial(registrations[8])
                                  .ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>(constructor);

                    return factory.ApplyPartial(registrations[11])
                                  .ApplyPartial(registrations[10])
                                  .ApplyPartial(registrations[9])
                                  .ApplyPartial(registrations[8])
                                  .ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>(constructor);

                    return factory.ApplyPartial(registrations[12])
                                  .ApplyPartial(registrations[11])
                                  .ApplyPartial(registrations[10])
                                  .ApplyPartial(registrations[9])
                                  .ApplyPartial(registrations[8])
                                  .ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>(constructor);

                    return factory.ApplyPartial(registrations[13])
                                  .ApplyPartial(registrations[12])
                                  .ApplyPartial(registrations[11])
                                  .ApplyPartial(registrations[10])
                                  .ApplyPartial(registrations[9])
                                  .ApplyPartial(registrations[8])
                                  .ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
    public class ConstructorRegistrationFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> :
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
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>(constructor);

                    return factory.ApplyPartial(registrations[14])
                                  .ApplyPartial(registrations[13])
                                  .ApplyPartial(registrations[12])
                                  .ApplyPartial(registrations[11])
                                  .ApplyPartial(registrations[10])
                                  .ApplyPartial(registrations[9])
                                  .ApplyPartial(registrations[8])
                                  .ApplyPartial(registrations[7])
                                  .ApplyPartial(registrations[6])
                                  .ApplyPartial(registrations[5])
                                  .ApplyPartial(registrations[4])
                                  .ApplyPartial(registrations[3])
                                  .ApplyPartial(registrations[2])
                                  .ApplyPartial(registrations[1])
                                  .ApplyPartial(registrations[0]);
                };
        }
    }
    
}
