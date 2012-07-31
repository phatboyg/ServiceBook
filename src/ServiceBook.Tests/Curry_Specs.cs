namespace ServiceBook.Tests
{
    using Factories;
    using NUnit.Framework;

    [TestFixture]
    public class Currying_a_factory_argument
    {
        [Test]
        public void Should_narrow_the_factory_width()
        {
            var factory = new ConstructorFactory<MyClass, MyDependency>(x => new MyClass(x));
            var dependencyFactory = new DefaultConstructorFactory<MyDependency>();
            var curryFactory = new CurryFactory<MyClass, MyDependency>(factory, dependencyFactory);
            MyClass subject = curryFactory.Get();

            Assert.IsNotNull(subject);
            Assert.IsNotNull(subject.Dependency);
        }

        class MyClass
        {
            public MyDependency Dependency { get; private set; }

            public MyClass(MyDependency dependency)
            {
                Dependency = dependency;
            }
        }

        class MyDependency
        {}
    }
}
