namespace ServiceBook.Registrations
{
    using System;

    public interface Registration
    {
        Type Type { get; }
    }

    public interface Registration<out T> :
        Registration
    {
        Factory<T> Factory { get; }

        T Get();
    }
}