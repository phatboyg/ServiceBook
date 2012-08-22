namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Factories;
    using Internals.Caching;
    using Registrations;

    public static class FactoryCandidateExtensions
    {
        static readonly Cache<int, Type> _factoryCache = new DictionaryCache<int, Type>();

        static FactoryCandidateExtensions()
        {
            _factoryCache.Add(0, typeof(ConstructorFactoryCandidate<>));
            _factoryCache.Add(1, typeof(ConstructorFactoryCandidate<,>));
            _factoryCache.Add(2, typeof(ConstructorFactoryCandidate<,,>));
            _factoryCache.Add(3, typeof(ConstructorFactoryCandidate<,,,>));
            _factoryCache.Add(4, typeof(ConstructorFactoryCandidate<,,,,>));
            _factoryCache.Add(5, typeof(ConstructorFactoryCandidate<,,,,,>));
            _factoryCache.Add(6, typeof(ConstructorFactoryCandidate<,,,,,,>));
            _factoryCache.Add(7, typeof(ConstructorFactoryCandidate<,,,,,,,>));
            _factoryCache.Add(8, typeof(ConstructorFactoryCandidate<,,,,,,,,>));
            _factoryCache.Add(9, typeof(ConstructorFactoryCandidate<,,,,,,,,,>));
            _factoryCache.Add(10, typeof(ConstructorFactoryCandidate<,,,,,,,,,,>));
            _factoryCache.Add(11, typeof(ConstructorFactoryCandidate<,,,,,,,,,,,>));
            _factoryCache.Add(12, typeof(ConstructorFactoryCandidate<,,,,,,,,,,,,>));
            _factoryCache.Add(13, typeof(ConstructorFactoryCandidate<,,,,,,,,,,,,,>));
            _factoryCache.Add(14, typeof(ConstructorFactoryCandidate<,,,,,,,,,,,,,,>));
            _factoryCache.Add(15, typeof(ConstructorFactoryCandidate<,,,,,,,,,,,,,,,>));
        }

        public static RegistrationFactory Create(Type type, ConstructorInfo constructorInfo)
        {
            var parameters = constructorInfo.GetParameters();

            if (!_factoryCache.Has(parameters.Length))
                throw new ArgumentException(
                    string.Format("Unable to create a factory for a constructor with {0} parameters",
                        parameters.Length), "constructorInfo");

            Type factoryType = _factoryCache[parameters.Length];

            Type[] genericTypes = Enumerable.Repeat(type, 1).Concat(dependencies.Select(x => x.RegistrationType)).ToArray();

            Type registrationType = factoryType.MakeGenericType(genericTypes);

            var factory = (RegistrationFactory)Activator.CreateInstance(registrationType, constructorInfo, dependencies);

            return factory;
        }
    }

    public abstract class ConstructorFactoryCandidate
    {
        readonly ConstructorInfo _constructorInfo;

        protected ConstructorFactoryCandidate(ConstructorInfo constructorInfo)
        {
            _constructorInfo = constructorInfo;
        }

        public IEnumerable<Dependency> Dependencies
        {
            get { return _constructorInfo.GetParameters().Select(x => x.ParameterType.GetDependency()); }
        }
    }


    public class ConstructorFactoryCandidate<T> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T>(constructor);

                    return factory;
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1>(constructor);

                    return factory.ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2>(constructor);

                    return factory.ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3>(constructor);

                    return factory.ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4>(constructor);

                    return factory.ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5>(constructor);

                    return factory.ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6>(constructor);

                    return factory.ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7>(constructor);

                    return factory.ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8>(constructor);

                    return factory.ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>(constructor);

                    return factory.ApplyPartial(registrations[8].Get())
                                  .ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>(constructor);

                    return factory.ApplyPartial(registrations[9].Get())
                                  .ApplyPartial(registrations[8].Get())
                                  .ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>(constructor);

                    return factory.ApplyPartial(registrations[10].Get())
                                  .ApplyPartial(registrations[9].Get())
                                  .ApplyPartial(registrations[8].Get())
                                  .ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>(constructor);

                    return factory.ApplyPartial(registrations[11].Get())
                                  .ApplyPartial(registrations[10].Get())
                                  .ApplyPartial(registrations[9].Get())
                                  .ApplyPartial(registrations[8].Get())
                                  .ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>(constructor);

                    return factory.ApplyPartial(registrations[12].Get())
                                  .ApplyPartial(registrations[11].Get())
                                  .ApplyPartial(registrations[10].Get())
                                  .ApplyPartial(registrations[9].Get())
                                  .ApplyPartial(registrations[8].Get())
                                  .ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>(constructor);

                    return factory.ApplyPartial(registrations[13].Get())
                                  .ApplyPartial(registrations[12].Get())
                                  .ApplyPartial(registrations[11].Get())
                                  .ApplyPartial(registrations[10].Get())
                                  .ApplyPartial(registrations[9].Get())
                                  .ApplyPartial(registrations[8].Get())
                                  .ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
    public class ConstructorFactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> :
        ConstructorFactoryCandidate,
        FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>
    {
        public ConstructorFactoryCandidate(ConstructorInfo constructor)
            : base(constructor)
        {
        }

        Type FactoryCandidate.FactoryType 
        {
            get { return typeof(T); }
        }

        static Func<Factory<T>> GetConstructorFactory(ConstructorInfo constructor, RegistrationFactory[] registrations)
        {
            return () =>
                {
                    var factory = new ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>(constructor);

                    return factory.ApplyPartial(registrations[14].Get())
                                  .ApplyPartial(registrations[13].Get())
                                  .ApplyPartial(registrations[12].Get())
                                  .ApplyPartial(registrations[11].Get())
                                  .ApplyPartial(registrations[10].Get())
                                  .ApplyPartial(registrations[9].Get())
                                  .ApplyPartial(registrations[8].Get())
                                  .ApplyPartial(registrations[7].Get())
                                  .ApplyPartial(registrations[6].Get())
                                  .ApplyPartial(registrations[5].Get())
                                  .ApplyPartial(registrations[4].Get())
                                  .ApplyPartial(registrations[3].Get())
                                  .ApplyPartial(registrations[2].Get())
                                  .ApplyPartial(registrations[1].Get())
                                  .ApplyPartial(registrations[0].Get());
                };
        }
    }
    
}
