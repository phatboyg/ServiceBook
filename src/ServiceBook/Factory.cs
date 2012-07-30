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
}