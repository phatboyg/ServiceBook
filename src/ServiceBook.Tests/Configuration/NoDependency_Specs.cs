namespace ServiceBook.Tests.Configuration
{
    using NUnit.Framework;

    [TestFixture]
    public class Creating_a_class_with_no_dependencies
    {
        [Test]
        public void Should_work()
        {
            Container container = ContainerFactory.New(x =>
                {
                    //x.Unique<MyClass>();
                });

            Assert.IsNotNull(container);

            var subject = container.Get<MyClass>();
            var other = container.Get<MyClass>();

            Assert.IsNotNull(subject);

            Assert.IsFalse(ReferenceEquals(subject, other));
        }

        class MyClass
        {
        }
    }
}