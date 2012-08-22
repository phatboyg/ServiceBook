namespace ServiceBook.Tests
{
    using System.Linq;
    using NUnit.Framework;
    using Registrations;

    [TestFixture]
    public class Creating_a_dependency_type
    {
        [Test]
        public void Should_get_the_interface_type()
        {
            var dependency = typeof(IA).GetDependency();

            Assert.IsInstanceOf<TypeDependency>(dependency);

            Assert.IsEmpty(dependency.GenericArguments);
        }

        [Test]
        public void Should_get_an_open_generic()
        {
            var dependency = typeof(IB<>).GetDependency();

            Assert.IsInstanceOf<OpenGenericDependency>(dependency);
            Assert.AreEqual(1, dependency.GenericArguments.Length);
            Assert.AreEqual("T", dependency.GenericArguments[0].Name);
            Assert.IsTrue(dependency.GenericArguments[0].IsGenericParameter);
        }

        [Test]
        public void Should_get_an_closed_generic()
        {
            var dependency = typeof(IB<int>).GetDependency();

            Assert.IsInstanceOf<ClosedGenericDependency>(dependency);
            Assert.AreEqual(1, dependency.GenericArguments.Length);
            Assert.AreEqual("Int32", dependency.GenericArguments[0].Name);
            Assert.IsFalse(dependency.GenericArguments[0].IsGenericParameter);
        }

        [Test]
        public void Should_properly_discover_class_dependency_value()
        {
            var dependency = typeof(Subject<,>).GetDependency();

            Assert.IsInstanceOf<OpenGenericDependency>(dependency);

            var constructor = typeof(Subject<,>).GetConstructors().First();

            var constructorDependency = constructor.GetParameters().First().ParameterType.GetDependency();

            Assert.IsInstanceOf<OpenGenericDependency>(constructorDependency);


        }

        interface IA
        {
        }

        interface IB<T>
        {
        }

        interface IC<T>
        {
        }

        interface ID<T1,T2> :
            IB<T1>, IC<T2>
        {}

        class Subject<TKey, TValue>
        {
            public ID<TKey, TValue> Id { get; set; }

            public Subject(ID<TKey, TValue> id)
            {
                Id = id;
            }
        }
    }
}
