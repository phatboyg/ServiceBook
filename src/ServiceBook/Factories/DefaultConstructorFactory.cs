namespace ServiceBook.Factories
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public class DefaultConstructorFactory<T> :
        Factory<T>
    {
        readonly Func<T> _get;

        public DefaultConstructorFactory()
            : this(GetDefaultConstructor())
        {
        }

        public DefaultConstructorFactory(ConstructorInfo constructorInfo)
        {
            if (constructorInfo.GetParameters().Length != 0)
                throw new InvalidOperationException("Only a default constructor with no arguments can be used");

            _get = CompileNewExpression(constructorInfo);
        }

        T Factory<T>.Get()
        {
            return _get();
        }

        static ConstructorInfo GetDefaultConstructor()
        {
            ConstructorInfo constructorInfo = typeof(T).GetConstructor(Type.EmptyTypes);
            if (constructorInfo == null)
                throw new InvalidOperationException("A publicly accessible default constructor was not found.");

            return constructorInfo;
        }

        static Func<T> CompileNewExpression(ConstructorInfo constructor)
        {
            NewExpression newExpression = Expression.New(constructor);

            return Expression.Lambda<Func<T>>(newExpression).Compile();
        }
    }
}