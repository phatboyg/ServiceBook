namespace ServiceBook
{
    public interface Factory<T>
    {
        T Get();
    }

    public interface Factory<T, T1>
    {
        T Get(Factory<T1> arg1);
    }
}