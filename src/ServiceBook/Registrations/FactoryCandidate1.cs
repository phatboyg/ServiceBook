namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A candidate for a factory that would satisfy a registration
    /// </summary>
    public interface FactoryCandidate
    {
        /// <summary>
        /// The type the factory creates
        /// </summary>
        Type FactoryType { get; }

        /// <summary>
        /// The type of dependencies required by the factory
        /// </summary>
        IEnumerable<Dependency> Dependencies { get; }
    }

    public interface FactoryCandidate<T> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> :
        FactoryCandidate
    {
    }

    public interface FactoryCandidate<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> :
        FactoryCandidate
    {
    }

}
