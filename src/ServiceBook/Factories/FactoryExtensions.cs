namespace ServiceBook.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

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
    }
}