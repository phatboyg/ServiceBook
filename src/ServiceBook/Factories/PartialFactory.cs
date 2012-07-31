namespace ServiceBook.Factories
{
    public class PartialFactory<T,T1> :
        Factory<T>
    {
        readonly Factory<T1> _arg1;
        readonly Factory<T,T1> _factory;

        public PartialFactory(Factory<T,T1> factory, Factory<T1> arg1)
        {
            _factory = factory;
            _arg1 = arg1;
        }

        public T Get()
        {
            return _factory.Get(_arg1);
        }
    }

    public class PartialFactory<T,T1,T2> :
        Factory<T,T1>
    {
        readonly Factory<T2> _arg2;
        readonly Factory<T,T1,T2> _factory;

        public PartialFactory(Factory<T,T1,T2> factory, Factory<T2> arg2)
        {
            _factory = factory;
            _arg2 = arg2;
        }

        public T Get(Factory<T1> arg1)
        {
            return _factory.Get(arg1, _arg2);
        }
    }

    public class PartialFactory<T,T1,T2,T3> :
        Factory<T,T1,T2>
    {
        readonly Factory<T3> _arg3;
        readonly Factory<T,T1,T2,T3> _factory;

        public PartialFactory(Factory<T,T1,T2,T3> factory, Factory<T3> arg3)
        {
            _factory = factory;
            _arg3 = arg3;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2)
        {
            return _factory.Get(arg1, arg2, _arg3);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4> :
        Factory<T,T1,T2,T3>
    {
        readonly Factory<T4> _arg4;
        readonly Factory<T,T1,T2,T3,T4> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4> factory, Factory<T4> arg4)
        {
            _factory = factory;
            _arg4 = arg4;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3)
        {
            return _factory.Get(arg1, arg2, arg3, _arg4);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5> :
        Factory<T,T1,T2,T3,T4>
    {
        readonly Factory<T5> _arg5;
        readonly Factory<T,T1,T2,T3,T4,T5> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5> factory, Factory<T5> arg5)
        {
            _factory = factory;
            _arg5 = arg5;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, _arg5);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6> :
        Factory<T,T1,T2,T3,T4,T5>
    {
        readonly Factory<T6> _arg6;
        readonly Factory<T,T1,T2,T3,T4,T5,T6> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6> factory, Factory<T6> arg6)
        {
            _factory = factory;
            _arg6 = arg6;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, _arg6);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7> :
        Factory<T,T1,T2,T3,T4,T5,T6>
    {
        readonly Factory<T7> _arg7;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7> factory, Factory<T7> arg7)
        {
            _factory = factory;
            _arg7 = arg7;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, _arg7);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7>
    {
        readonly Factory<T8> _arg8;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8> factory, Factory<T8> arg8)
        {
            _factory = factory;
            _arg8 = arg8;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, _arg8);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8>
    {
        readonly Factory<T9> _arg9;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> factory, Factory<T9> arg9)
        {
            _factory = factory;
            _arg9 = arg9;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, _arg9);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>
    {
        readonly Factory<T10> _arg10;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> factory, Factory<T10> arg10)
        {
            _factory = factory;
            _arg10 = arg10;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, _arg10);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>
    {
        readonly Factory<T11> _arg11;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> factory, Factory<T11> arg11)
        {
            _factory = factory;
            _arg11 = arg11;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, _arg11);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>
    {
        readonly Factory<T12> _arg12;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> factory, Factory<T12> arg12)
        {
            _factory = factory;
            _arg12 = arg12;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, _arg12);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>
    {
        readonly Factory<T13> _arg13;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> factory, Factory<T13> arg13)
        {
            _factory = factory;
            _arg13 = arg13;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, _arg13);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>
    {
        readonly Factory<T14> _arg14;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> factory, Factory<T14> arg14)
        {
            _factory = factory;
            _arg14 = arg14;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, _arg14);
        }
    }

    public class PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> :
        Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>
    {
        readonly Factory<T15> _arg15;
        readonly Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> _factory;

        public PartialFactory(Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> factory, Factory<T15> arg15)
        {
            _factory = factory;
            _arg15 = arg15;
        }

        public T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13, Factory<T14> arg14)
        {
            return _factory.Get(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, _arg15);
        }
    }

}
