namespace ServiceBook.Tests.Benchmarks
{
    public class ParentObject
    {
        readonly DependentObject _dependent;

        public ParentObject(DependentObject dependent)
        {
            _dependent = dependent;
        }
    }
}