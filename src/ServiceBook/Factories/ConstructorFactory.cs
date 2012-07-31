namespace ServiceBook.Factories
{
    using System;
    using System.Reflection;
    using System.Linq.Expressions;

    public class ConstructorFactory<T> :
        Factory<T>
    {
        readonly Func<T> _get;

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

        T Factory<T>.Get()
        {
            return _get();
        }
    }


    public class ConstructorFactory<T,T1> :
        Factory<T,T1>
    {
        readonly Func<T1,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T>>(newExpression.Constructor);
        }

        T Factory<T,T1>.Get(Factory<T1> arg1)
        {
            return _get(arg1.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2> :
        Factory<T,T1,T2>
    {
        readonly Func<T1,T2,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2>.Get(Factory<T1> arg1, Factory<T2> arg2)
        {
            return _get(arg1.Get(), arg2.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3> :
        Factory<T,T1,T2,T3>
    {
        readonly Func<T1,T2,T3,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4> :
        Factory<T,T1,T2,T3,T4>
    {
        readonly Func<T1,T2,T3,T4,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5> :
        Factory<T,T1,T2,T3,T4,T5>
    {
        readonly Func<T1,T2,T3,T4,T5,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6> :
        Factory<T,T1,T2,T3,T4,T5,T6>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get(), arg9.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get(), arg9.Get(), arg10.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get(), arg9.Get(), arg10.Get(), arg11.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get(), arg9.Get(), arg10.Get(), arg11.Get(), arg12.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get(), arg9.Get(), arg10.Get(), arg11.Get(), arg12.Get(), arg13.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13, Factory<T14> arg14)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get(), arg9.Get(), arg10.Get(), arg11.Get(), arg12.Get(), arg13.Get(), arg14.Get());
        }
    }


    public class ConstructorFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>
    {
        readonly Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T> _get;

        public ConstructorFactory(ConstructorInfo constructorInfo)
        {
            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T>>(constructorInfo);
        }

        public ConstructorFactory(Expression<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T>> constructorExpression)
        {
            var newExpression = constructorExpression.Body as NewExpression;
            if (newExpression == null)
                throw new ArgumentException("Only a constructor can be specified", "constructorExpression");

            _get = this.GetFactoryMethod<Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T>>(newExpression.Constructor);
        }

        T Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13, Factory<T14> arg14, Factory<T15> arg15)
        {
            return _get(arg1.Get(), arg2.Get(), arg3.Get(), arg4.Get(), arg5.Get(), arg6.Get(), arg7.Get(), arg8.Get(), arg9.Get(), arg10.Get(), arg11.Get(), arg12.Get(), arg13.Get(), arg14.Get(), arg15.Get());
        }
    }


}
