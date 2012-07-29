namespace ServiceBook.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Using_a_factory_to_get_an_object
    {
        [Test]
        public void Should_work()
        {
            var factory = new NoArgumentFactory<MyClass>(() => new MyClass());

            MyClass subject = factory.Get();

            Assert.IsNotNull(subject);
        }

        class MyClass
        {
        }
    }
}