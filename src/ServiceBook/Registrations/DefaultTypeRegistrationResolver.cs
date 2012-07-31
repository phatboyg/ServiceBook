namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Conventions;
    using Factories;
    using Internals.Extensions;


    public class DefaultTypeRegistrationResolver
    {
        public IEnumerable<Registration> Resolve(Type type)
        {
            return ResolveIfConcreteType(type);
        }

        IEnumerable<Registration> ResolveIfConcreteType(Type type)
        {
            if (!type.IsConcreteType())
                yield break;

            var constructorInfo = type.GetConstructor(new Type[] {});

            if (constructorInfo != null)
            {
                var registrationType = typeof(ConstructorRegistrationFactory<>).MakeGenericType(type);

                var registrationFactory = (RegistrationFactory)Activator.CreateInstance(registrationType, constructorInfo);

                yield return registrationFactory.Get();
            }




            /*
            IOrderedEnumerable<ConstructorInfo> candidates = type.GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length);



            foreach (ConstructorInfo candidate in candidates)
            {
                try
                {
                    Add(addType, implementationType, candidate.GetParameters().Select(x => x.ParameterType).ToArray());
                    return;
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
            }

            throw lastException ?? new InvalidOperationException(
                                       string.Format("No constructor on type '{0}' could be satisfied", addType.Name));
        }

        void Add(Type addType, Type implementationType, params Type[] dependencies)
        {
            if (!implementationType.IsConcreteType())
                throw new ArgumentException(string.Format("The implementation type '{0}' must be a concrete type",
                    implementationType.Name));

            if (!addType.IsAssignableFrom(implementationType))
                throw new ArgumentException(
                    string.Format("The implementation type '{0}' must be assignable to the added type '{1}'",
                        implementationType.Name, addType.Name));

            ConstructorInfo constructor = implementationType.GetConstructor(dependencies);
            if (constructor == null)
                throw new ArgumentException(
                    string.Format("No constructor on type '{0}' accepts ({1})", implementationType.Name,
#if !NET35
                        string.Join(",", dependencies.Select(x => x.Name))));
#else
                        string.Join(",", dependencies.Select(x => x.Name).ToArray())));
#endif

            ParameterInfo[] parameters = constructor.GetParameters();

            IEnumerable<Expression> arguments = dependencies
                .Select((type, index) => GetResolveExpression(parameters[index].ParameterType));

            NewExpression newExpression = Expression.New(constructor, arguments);

            Delegate factoryMethod = Expression.Lambda(Expression.TypeAs(newExpression, implementationType)).Compile();

            try
            {
                _add.MakeGenericMethod(addType).Invoke(null, new object[] {factoryMethod});
            }
            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        Expression GetResolveExpression(Type type)
        {
            return Expression.Call(null, _get.MakeGenericMethod(type));
        }*/
        }
    }
}