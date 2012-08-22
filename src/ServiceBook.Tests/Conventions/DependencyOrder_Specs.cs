namespace ServiceBook.Tests.Conventions
{
    using System.Linq;
    using NUnit.Framework;
    using Registrations;
    using ServiceBook.Conventions;
    using StructureMap.Util;

    [TestFixture]
    public class When_determining_the_dependency_order_by_convention
    {
        [Test]
        public void Should_properly_order_dependencies()
        {
            var convention = new ConcreteTypeRegistrationConvention();

            var emptyContainer = new TestContainer();

            RegistrationCatalog catalog = new ContainerRegistrationCatalog(convention, emptyContainer);

            catalog.GetRegistration(typeof(Parent));

            RegistrationFactory[] dependencies = catalog.Registrations.ToArray();

            Assert.AreEqual(
                new[] {typeof(Sibling), typeof(GrandChild), typeof(Child), typeof(GrandParent), typeof(Parent)},
                dependencies.Select(x => x.RegistrationType));
        }

        [Test]
        public void Should_properly_order_dependencies_not_including_existing_ones()
        {
            var convention = new ConcreteTypeRegistrationConvention();

            var testContainer = new TestContainer(typeof(Sibling));

            RegistrationCatalog catalog = new ContainerRegistrationCatalog(convention, testContainer);

            catalog.GetRegistration(typeof(Parent));

            RegistrationFactory[] dependencies = catalog.Registrations.ToArray();

            Assert.AreEqual(
                new[] {typeof(GrandChild), typeof(Child), typeof(GrandParent), typeof(Parent)},
                dependencies.Select(x => x.RegistrationType));
        }

        class Parent
        {
            public Parent(Child child, Sibling sibling, GrandParent grandParent)
            {
            }
        }

        class Sibling
        {
        }

        class GrandParent
        {
        }

        class Child
        {
            public Child(GrandChild child)
            {
            }
        }

        class GrandChild
        {
            public GrandChild(Sibling sibling)
            {
            }
        }
    }
}