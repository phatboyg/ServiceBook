namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A possible factory for a type, given the specified parameter types needed to invoke
    /// the constructor for the object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface FactoryCandidate<T>
    {
         
    }

    public interface FactoryCandidate<T, T1>
    {
        
    }


    public interface IFactoryCandidate
    {
        Type FactoryType { get; }

        IEnumerable<Type> DependencyTypes { get; }
    }
}