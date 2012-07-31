namespace ServiceBook.Factories
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public class ConstructorFactory<T> :
        Factory<T>
    {
        Func<T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T>>(newExpression.Constructor);
        }

        public T Get()
        {
            return _get();
        }
    }

    public class ConstructorFactory<T, T1> :
        Factory<T, T1>
    {
        Func<T1, T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1, T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1, T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1, T>>(newExpression.Constructor);
        }

        public T Get(Factory<T1> arg1)
        {
            return _get(arg1.Get());
        }
    }

    public class ConstructorFactory<T, T1, T2> :
        Factory<T, T1, T2>
    {
        readonly Func<T1, T2, T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1, T2, T>>(constructorInfo);
        }

        T Factory<T, T1, T2>.Get(Factory<T1> arg1, Factory<T2> arg2)
        {
            return _get(arg1.Get(), arg2.Get());
        }
    }

    public class ConstructorFactory<T, T1, T2, T3> :
        Factory<T, T1, T2, T3>
    {
        readonly Func<T1, T2, T3, T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1, T2, T3, T>>(constructorInfo);
        }

        T Factory<T, T1, T2, T3>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get());
        }
    }

    public class ConstructorFactory<T, T1, T2, T3, T4> :
        Factory<T, T1, T2, T3, T4>
    {
        readonly Func<T1, T2, T3, T4, T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1, T2, T3, T4, T>>(constructorInfo);
        }

        T Factory<T, T1, T2, T3, T4>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get());
        }
    }
}