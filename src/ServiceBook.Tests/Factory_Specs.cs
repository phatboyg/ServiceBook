namespace ServiceBook.Tests
{
    using Factories;
    using NUnit.Framework;

    [TestFixture]
    public class Using_a_factory_to_get_an_object
    {
        [Test]
        public void Should_work()
        {
            Factory<MyClass> factory = new DefaultConstructorFactory<MyClass>();

            MyClass subject = factory.Get();

            Assert.IsNotNull(subject);
        }

        class MyClass
        {
        }
    }
}