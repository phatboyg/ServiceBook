namespace ServiceBook.Factories
{
    public class CurryFactory<T, T1> :
        Factory<T>
    {
        Factory<T1> _arg1;
        Factory<T, T1> _factory;

        public CurryFactory(Factory<T, T1> factory, Factory<T1> arg1)
        {
            _factory = factory;
            _arg1 = arg1;
        }

        public T Get()
        {
            return _factory.Get(_arg1);
        }
    }

    public class CurryFactory<T, T1, T2> :
        Factory<T, T1>
    {
        readonly Factory<T2> _arg2;
        readonly Factory<T, T1, T2> _factory;

        public CurryFactory(Factory<T, T1, T2> factory, Factory<T2> arg2)
        {
            _factory = factory;
            _arg2 = arg2;
        }

        T Factory<T, T1>.Get(Factory<T1> arg1)
        {
            return _factory.Get(arg1, _arg2);
        }
    }

    public class CurryFactory<T, T1, T2, T3> :
        Factory<T, T1, T2>
    {
        readonly Factory<T3> _arg3;
        readonly Factory<T, T1, T2, T3> _factory;

        public CurryFactory(Factory<T, T1, T2, T3> factory, Factory<T3> arg3)
        {
            _factory = factory;
            _arg3 = arg3;
        }

        T Factory<T, T1, T2>.Get(Factory<T1> arg1, Factory<T2> arg2)
        {
            return _factory.Get(arg1, arg2, _arg3);
        }
    }

    public class CurryFactory<T, T1, T2, T3, T4> :
        Factory<T, T1, T2, T3>
    {
        readonly Factory<T4> _arg4;
        readonly Factory<T, T1, T2, T3, T4> _factory;

        public CurryFactory(Factory<T, T1, T2, T3, T4> factory, Factory<T4> arg4)
        {
            _factory = factory;
            _arg4 = arg4;
        }

        T Factory<T, T1, T2, T3>.Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3)
        {
            return _factory.Get(arg1, arg2, arg3, _arg4);
        }
    }
}