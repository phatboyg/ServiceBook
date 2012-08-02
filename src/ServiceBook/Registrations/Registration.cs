namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    public interface Registration
    {
        Type Type { get; }

        IEnumerable<Registration> Dependencies { get; }
    }

    public interface Registration<out T> :
        Registration
    {
        Factory<T> Factory { get; }

        T Get();
    }

    public interface GenericRegistration :
        Registration
    {

    }
}