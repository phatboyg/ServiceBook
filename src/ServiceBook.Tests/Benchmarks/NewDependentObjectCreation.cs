namespace ServiceBook.Tests.Benchmarks
{
    public class NewDependentObjectCreation :
        DependentObjectCreation
    {
        public ParentObject Get()
        {
            return new ParentObject(new DependentObject());
        }
    }
}