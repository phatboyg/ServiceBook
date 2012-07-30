namespace ServiceBook
{
    public interface Container
    {
        T Get<T>();
    }
}