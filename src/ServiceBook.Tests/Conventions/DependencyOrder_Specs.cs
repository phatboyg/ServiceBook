namespace ServiceBook.Tests.Conventions
{
    using System;
    using System.Collections.Generic;
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

        class TestContainer :
            ConfigureContainer
        {
            readonly IDictionary<Type, Registration> _existing;

            public TestContainer(params Type[] existingTypes)
            {
                _existing = new Dictionary<Type, Registration>();

                foreach (var existingType in existingTypes)
                {
                    _existing.Add(existingType, new BogusRegistration(existingType));
                }
            }

            public bool TryGetRegistration(Type type, out Registration registration)
            {
                return _existing.TryGetValue(type, out registration);
            }

            public void AddRegistration(Registration registration)
            {
                throw new InvalidOperationException("Should not be adding anything!!!!");
            }

            class BogusRegistration :
                Registration
            {
                Type _type;

                public BogusRegistration(Type type)
                {
                    _type = type;
                }

                public Type Type
                {
                    get { return _type; }
                }

                public IEnumerable<Registration> Dependencies
                {
                    get { yield break; }
                }
            }
        }
    }
}