namespace ServiceBook.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class FactoryImpl<T> :
        Factory<T>
    {
        Func<T> _get;

        public FactoryImpl(ConstructorInfo constructorInfo)
        {
            if (constructorInfo.GetParameters().Length != 1)
                throw new InvalidOperationException("One constructor argument is required for this factory");

            _get = CompileNewExpression(constructorInfo);
        }

        public FactoryImpl(Expression<Func<T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if(newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = CompileNewExpression(newExpression.Constructor);
        }

        public T Get()
        {
            return _get();
        }

        Func<T> CompileNewExpression(ConstructorInfo constructor)
        {
            IEnumerable<ParameterExpression> parameters = this.GetParameterExpressions().ToArray();

            NewExpression newExpression = Expression.New(constructor, parameters.Select(x => (Expression)x));

            return Expression.Lambda<Func<T>>(newExpression, parameters).Compile();
        }
    }
    public class FactoryImpl<T, T1> :
        Factory<T, T1>
    {
        Func<T1, T> _get;

        public FactoryImpl(ConstructorInfo constructorInfo)
        {
            if (constructorInfo.GetParameters().Length != 1)
                throw new InvalidOperationException("One constructor argument is required for this factory");

            _get = CompileNewExpression(constructorInfo);
        }

        public FactoryImpl(Expression<Func<T1, T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if(newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = CompileNewExpression(newExpression.Constructor);
        }

        public T Get(Factory<T1> arg1)
        {
            return _get(arg1.Get());
        }

        Func<T1, T> CompileNewExpression(ConstructorInfo constructor)
        {
            IEnumerable<ParameterExpression> parameters = this.GetParameterExpressions().ToArray();

            NewExpression newExpression = Expression.New(constructor, parameters.Select(x => (Expression)x));

            return Expression.Lambda<Func<T1, T>>(newExpression, parameters).Compile();
        }
    }

    public class FactoryImpl<T, T1, T2> :
        Factory<T, T1, T2>
    {
        readonly Func<T1, T2, T> _get;

        public FactoryImpl(ConstructorInfo constructorInfo)
        {
            if (constructorInfo.GetParameters().Length != 2)
                throw new InvalidOperationException("Two constructor arguments are required for this factory");

            _get = CompileNewExpression(constructorInfo);
        }

        T Factory<T, T1, T2>.Get(Factory<T1> arg1, Factory<T2> arg2)
        {
            return _get(arg1.Get(), arg2.Get());
        }

        Func<T1, T2, T> CompileNewExpression(ConstructorInfo constructor)
        {
            IEnumerable<ParameterExpression> parameters = this.GetParameterExpressions().ToArray();

            NewExpression newExpression = Expression.New(constructor, parameters.Select(x => (Expression)x));

            return Expression.Lambda<Func<T1, T2, T>>(newExpression, parameters).Compile();
        }
    }
}