namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Registration Factory is contains the details necessary to create a Registration,
    /// which can be added to the container.
    /// </summary>
    public interface RegistrationFactory
    {
        /// <summary>
        /// The factory type that is registered by this registration
        /// </summary>
        Type RegistrationType { get; }

        /// <summary>
        /// Returns the candidate factories for the registration, which may include candidates
        /// that cannot actually be created due to unrealized dependencies
        /// </summary>
        IEnumerable<RegistrationFactoryCandidate> Candidates { get; }

        /// <summary>
        /// Get the registration
        /// </summary>
        /// <returns></returns>
        Registration Get();
    }

//    public class asdfRegistrationCatalog
//    {
//            readonly Cache<Type, Registration> _registrations;
//        readonly Cache<int, > 
//
//            int _key;
//
//            public RegistrationCatalog()
//            {
//                _registrations = new ConcurrentCache<Type, Registration>();
//
//            }
//
//            public IDisposable Subscribe(IObserver<T> observer)
//            {
//                if (observer == null)
//                    throw new ArgumentNullException("observer");
//
//                int observerId = Interlocked.Increment(ref _key);
//
//                _observers.Add(observerId, observer);
//
//                return new ObserverReference(observerId, id => _observers.Remove(id));
//            }
//
//            public void OnNext(T value)
//            {
//                _observers.Each(x => x.OnNext(value));
//            }
//
//            public void OnError(Exception exception)
//            {
//                if (exception == null)
//                    throw new ArgumentNullException("exception");
//
//                _observers.Each(x => x.OnError(exception));
//            }
//
//            public void OnCompleted()
//            {
//                _observers.Each(x => x.OnCompleted());
//            }
//
//
//            class ObserverReference :
//                IDisposable
//            {
//                readonly int _observerId;
//                readonly Action<int> _removeObserver;
//
//                public ObserverReference(int observerId, Action<int> removeObserver)
//                {
//                    _observerId = observerId;
//                    _removeObserver = removeObserver;
//                }
//
//                public void Dispose()
//                {
//                    _removeObserver(_observerId);
//                }
//            }
//        }
}