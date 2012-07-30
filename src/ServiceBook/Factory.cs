namespace ServiceBook
{
    public interface Factory<out T>
    {
        T Get();
    }

    public interface Factory<out T, in T1>
    {
        T Get(Factory<T1> arg1);
    }
}