namespace ServiceBook.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

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
    }
}