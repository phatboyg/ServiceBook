namespace ServiceBook.Tests.Configuration
{
    using NUnit.Framework;

    [TestFixture]
    public class Creating_an_empty_container
    {
        [Test]
        public void Should_build_a_container()
        {
            Container container = ContainerFactory.New(x => { });

            Assert.IsNotNull(container);
        }
    }
}