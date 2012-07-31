namespace ServiceBook
{
    using Factories;

    public interface Factory<out T> :
        IFactory
    {
        T Get();
    }
    public interface Factory<out T,in T1> :
        IFactory
    {
        T Get(Factory<T1> arg1);
    }
    public interface Factory<out T,in T1,in T2> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2);
    }
    public interface Factory<out T,in T1,in T2,in T3> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9,in T10> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9,in T10,in T11> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9,in T10,in T11,in T12> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9,in T10,in T11,in T12,in T13> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9,in T10,in T11,in T12,in T13,in T14> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13, Factory<T14> arg14);
    }
    public interface Factory<out T,in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9,in T10,in T11,in T12,in T13,in T14,in T15> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4, Factory<T5> arg5, Factory<T6> arg6, Factory<T7> arg7, Factory<T8> arg8, Factory<T9> arg9, Factory<T10> arg10, Factory<T11> arg11, Factory<T12> arg12, Factory<T13> arg13, Factory<T14> arg14, Factory<T15> arg15);
    }
}