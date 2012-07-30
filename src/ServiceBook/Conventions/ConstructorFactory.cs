namespace ServiceBook.Conventions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class ConstructorFactory<T, T1> :
        Factory<T>
    {
        readonly Factory<T1> _arg1;
        readonly Func<T1, T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo, Factory<T1> arg1)
        {
            if (constructorInfo.GetParameters().Length != 1)
                throw new InvalidOperationException("One constructor argument is required for this factory");

            _arg1 = arg1;
            _get = CompileNewExpression(constructorInfo);
        }

        T Factory<T>.Get()
        {
            return _get(_arg1.Get());
        }

        Func<T1, T> CompileNewExpression(ConstructorInfo constructor)
        {
            ParameterExpression[] parameters = GetConstructorParameters();

            NewExpression newExpression = Expression.New(constructor, parameters.Select(x => (Expression)x));

            return Expression.Lambda<Func<T1, T>>(newExpression, parameters).Compile();
        }

        ParameterExpression[] GetConstructorParameters()
        {
            return GetType().GetGenericArguments()
                .Skip(1)
                .Select((x, index) => Expression.Parameter(x, string.Format("argument{0}", index)))
                .ToArray();
        }
    }

    public class ConstructorFactory<T, T1, T2> :
        Factory<T>
    {
        readonly Factory<T1> _arg1;
        readonly Factory<T2> _arg2;
        readonly Func<T1, T2, T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo, Factory<T1> arg1, Factory<T2> arg2)
        {
            if (constructorInfo.GetParameters().Length != 2)
                throw new InvalidOperationException("Two constructor arguments are required for this factory");

            _arg1 = arg1;
            _arg2 = arg2;
            _get = CompileNewExpression(constructorInfo);
        }

        T Factory<T>.Get()
        {
            return _get(_arg1.Get(), _arg2.Get());
        }

        Func<T1, T2, T> CompileNewExpression(ConstructorInfo constructor)
        {
            ParameterExpression[] parameters = GetConstructorParameters();

            NewExpression newExpression = Expression.New(constructor, parameters.Select(x => (Expression)x));

            return Expression.Lambda<Func<T1, T2, T>>(newExpression, parameters).Compile();
        }

        ParameterExpression[] GetConstructorParameters()
        {
            return GetType().GetGenericArguments()
                .Skip(1)
                .Select((x, index) => Expression.Parameter(x, string.Format("argument{0}", index)))
                .ToArray();
        }
    }
}