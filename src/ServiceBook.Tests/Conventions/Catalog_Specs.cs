namespace ServiceBook.Tests.Conventions
{
    using Builders;
    using NUnit.Framework;
    using Registrations.RegistrationFactories;

    [TestFixture]
    public class Catalog_Specs
    {
        [Test]
        public void FirstTestName()
        {
            CatalogBuilder builder = new CatalogBuilderImpl();

            var type = typeof(Subject);
            var constructor = type.GetConstructor(new[] {typeof(ISomething)});

            builder.AddRegistrationFactory(ConstructorRegistrationFactory.Create(type, constructor));

            builder.Build();
        }

        interface ISomething
        {
        }

        class Something
        {
        }

        class Subject
        {
            public ISomething Something { get; set; }

            public Subject(ISomething something)
            {
                Something = something;
            }
        }
    }
}
