namespace ServiceBook.Tests.Conventions
{
    using System.Linq;
    using Factories;
    using NUnit.Framework;
    using Registrations;
    using Registrations.RegistrationFactories;
    using ServiceBook.Conventions;

    [TestFixture]
    public class When_adding_an_interface_using_a_catalog
    {
        [Test]
        public void Should_use_the_provider_factory()
        {
            var testContainer = new TestContainer();

            var convention = new ConcreteTypeRegistrationConvention();

            RegistrationCatalog catalog = new ContainerRegistrationCatalog(convention, testContainer);

            var factory = new ConstructorFactory<ISomething>(() => new Something());

            Registration registration = new ClosedTypeRegistration<ISomething>(factory);

            var registrationFactory = new ClosedTypeRegistrationFactory<ISomething>(() => factory);

            catalog.AddRegistration(registrationFactory);

            RegistrationFactory[] dependencies = catalog.Registrations.ToArray();

            Assert.AreEqual(new[] {typeof(ISomething)}, dependencies.Select(x => x.RegistrationType));
        }

        interface ISomething
        {
        }

        class Something : ISomething
        {
        }

        class Subject
        {
            public Subject(ISomething something)
            {
                Something = something;
            }

            public ISomething Something { get; set; }
        }
    }
}