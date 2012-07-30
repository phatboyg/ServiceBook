namespace ServiceBook.Tests.Performance
{
    using NUnit.Framework;

    [TestFixture, Explicit]
    public class The_container
    {
        [Test]
        public void Should_be_fast()
        {
            Container container = ContainerFactory.New(x => { });

            var first = container.Get<MyClass>();


            for (int i = 0; i < 10000000; i++)
            {
                var next = container.Get<MyClass>();
            }
        }

        class MyClass
        {
        }
    }
}