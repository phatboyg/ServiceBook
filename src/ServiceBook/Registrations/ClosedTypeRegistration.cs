namespace ServiceBook.Registrations
{
    using System;

    public class ClosedTypeRegistration<T> :
        Registration<T>
    {
        readonly Factory<T> _factory;

        public ClosedTypeRegistration(Factory<T> factory)
        {
            _factory = factory;
        }

        public T Get()
        {
            return _factory.Get();
        }

        public Type Type
        {
            get { return typeof(T); }
        }
    }
}