namespace ServiceBook
{
    using Factories;

    public interface Factory<out T> :
        IFactory
    {
        T Get();
    }

    public interface Factory<out T, in T1> :
        IFactory
    {
        T Get(Factory<T1> arg1);
    }

    public interface Factory<out T, in T1, in T2> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2);
    }

    public interface Factory<out T, in T1, in T2, in T3> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3);
    }

    public interface Factory<out T, in T1, in T2, in T3, in T4> :
        IFactory
    {
        T Get(Factory<T1> arg1, Factory<T2> arg2, Factory<T3> arg3, Factory<T4> arg4);
    }
}