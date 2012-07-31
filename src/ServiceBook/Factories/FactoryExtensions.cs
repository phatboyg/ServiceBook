namespace ServiceBook.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Registrations;

    public static class FactoryExtensions
    {
        public static IEnumerable<Type> GetParameterTypes<T>(this T factory)
            where T : IFactory
        {
            return factory.GetType().GetGenericArguments()
                .Skip(1);
        }

        public static IEnumerable<ParameterExpression> GetParameterExpressions<T>(this T factory)
            where T : IFactory
        {
            return factory.GetType().GetGenericArguments()
                .Skip(1)
                .Select((x, index) => Expression.Parameter(x, string.Format("argument{0}", index)));
        }

        public static T GetFactoryMethod<T>(this IFactory factory, ConstructorInfo constructorInfo)
        {
            ParameterExpression[] parameters = factory.GetType().GetGenericArguments()
                .Skip(1)
                .Select((x, index) => Expression.Parameter(x, string.Format("argument{0}", index)))
                .ToArray();

            if (constructorInfo.GetParameters().Length != parameters.Length)
                throw new InvalidOperationException(
                    string.Format("This factory requires {0} constructor arguments", parameters.Length));

            NewExpression newExpression = Expression.New(constructorInfo, parameters.Select(x => (Expression)x));

            return Expression.Lambda<T>(newExpression, parameters).Compile();
        }

        public static Factory<T> GetFactory<T>(this Registration registration)
        {
            var factoryRegistration = registration as Registration<T>;
            if (factoryRegistration == null)
                throw new ArgumentException(string.Format("The registration type was not valid: {0}",
                    registration.Type));

            return factoryRegistration.Factory;
        }

        public static Factory<T> ApplyPartial<T, T1>(this Factory<T, T1> source, Registration registration)
        {
            var partial = new PartialFactory<T, T1>(source, registration.GetFactory<T1>());

            return partial;
        }

        public static Factory<T, T1> ApplyPartial<T, T1, T2>(this Factory<T, T1, T2> source, Registration registration)
        {
            var partial = new PartialFactory<T, T1, T2>(source, registration.GetFactory<T2>());

            return partial;
        }

        public static Factory<T, T1, T2> ApplyPartial<T, T1, T2, T3>(this Factory<T, T1, T2, T3> source,
            Registration registration)
        {
            var partial = new PartialFactory<T, T1, T2, T3>(source, registration.GetFactory<T3>());

            return partial;
        }

        public static Factory<T, T1, T2, T3> ApplyPartial<T, T1, T2, T3, T4>(this Factory<T, T1, T2, T3, T4> source,
            Registration registration)
        {
            var partial = new PartialFactory<T, T1, T2, T3, T4>(source, registration.GetFactory<T4>());

            return partial;
        }

        public static Factory<T, T1, T2, T3, T4> ApplyPartial<T, T1, T2, T3, T4, T5>(
            this Factory<T, T1, T2, T3, T4, T5> source, Registration registration)
        {
            var partial = new PartialFactory<T, T1, T2, T3, T4, T5>(source, registration.GetFactory<T5>());

            return partial;
        }
    }
}