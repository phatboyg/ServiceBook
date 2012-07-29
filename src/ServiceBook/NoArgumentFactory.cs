namespace ServiceBook
{
    using System;

    public class NoArgumentFactory<T> :
        Factory<T>
    {
        readonly Func<T> _new;

        public NoArgumentFactory(Func<T> @new)
        {
            _new = @new;
        }

        public T Get()
        {
            return _new();
        }
    }
}