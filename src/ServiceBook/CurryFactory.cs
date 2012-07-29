namespace ServiceBook
{
    public class CurryFactory<T, T1> :
        Factory<T>
    {
        Factory<T1> _arg1;
        Factory<T, T1> _factory;

        public CurryFactory(Factory<T, T1> factory, Factory<T1> arg1)
        {
            _factory = factory;
            _arg1 = arg1;
        }

        public T Get()
        {
            return _factory.Get(_arg1);
        }
    }
}