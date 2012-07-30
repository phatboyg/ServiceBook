namespace ServiceBook
{
    public interface ReleaseHandler
    {
        void OnRelease(object obj);
    }

    public interface ReleaseHandler<T> :
        ReleaseHandler
    {
    }
}