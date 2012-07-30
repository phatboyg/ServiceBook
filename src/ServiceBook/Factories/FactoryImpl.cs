namespace ServiceBook.Factories
{
    using System;

    public class FactoryImpl<T, T1> : 
        Factory<T,T1>
    {
        Func<T1, T> _get;

        public FactoryImpl(Func<T1, T> get)
        {
            _get = get;
        }

        public T Get(Factory<T1> arg1)
        {
            return _get(arg1.Get());
        }
    }
}