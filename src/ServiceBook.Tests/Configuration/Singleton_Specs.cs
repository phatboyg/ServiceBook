namespace ServiceBook.Tests.Configuration
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Configuring_a_singleton
    {
        [Test]
        public void Should_return_a_singleton_from_the_container()
        {
            var container = ContainerFactory.New(x =>
                {
                    x.Singleton<MyClass>();
                });

            var first = container.Get<MyClass>();
            var second = container.Get<MyClass>();

            Assert.AreEqual(first.Id, second.Id, "Guids should match for the same object");
            Assert.ReferenceEquals(first, second);
        }

        class MyClass
        {
            Guid _id;

            public Guid Id
            {
                get { return _id; }
            }

            public MyClass()
            {
                _id = Guid.NewGuid();
            }
        }
    }
}
