namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;

    public class ClosedTypeRegistration<T> :
        Registration<T>
    {
        readonly Registration[] _dependencies;
        readonly Factory<T> _factory;

        public ClosedTypeRegistration(Factory<T> factory, params Registration[] dependencies)
        {
            _factory = factory;
            _dependencies = dependencies;
        }

        public Factory<T> Factory
        {
            get { return _factory; }
        }

        public T Get()
        {
            return _factory.Get();
        }

        public Type Type
        {
            get { return typeof(T); }
        }

        public IEnumerable<Registration> Dependencies
        {
            get { return _dependencies; }
        }
    }
}