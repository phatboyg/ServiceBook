namespace ServiceBook.Tests.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Registrations;
    using Registrations.Algorithms;
    using ServiceBook.Conventions;

    [TestFixture]
    public class When_determining_the_dependency_order_by_convention
    {
        [Test]
        public void Should_properly_order_dependencies()
        {
            var convention = new ConcreteTypeRegistrationConvention();

            var catalog = new MyCatalog(convention);

            Registration registration = catalog.GetRegistration(typeof(Parent));

            Type[] dependencies = catalog.Dependencies(typeof(Parent)).ToArray();

            Assert.AreEqual(
                new[] {typeof(Sibling), typeof(GrandChild), typeof(Child), typeof(GrandParent), typeof(Parent)},
                dependencies);
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

        class MyCatalog :
            RegistrationCatalog
        {
            readonly RegistrationConvention _convention;
            readonly DependencyGraph<Type> _graph;
            readonly IDictionary<Type, Registration> _types;

            public MyCatalog(RegistrationConvention convention)
            {
                _types = new Dictionary<Type, Registration>();
                _graph = new DependencyGraph<Type>();

                _convention = convention;
            }

            public Registration GetRegistration(Type type)
            {
                IEnumerable<Registration> typeRegistrations = _convention.GetTypeRegistrations(this, type);
                foreach (Registration registration in typeRegistrations)
                {
                    _types[registration.Type] = registration;

                    if (type != registration.Type)
                        _graph.Add(type, registration.Type);
                }

                return _types[type];
            }

            public IEnumerable<Type> Dependencies(Type type)
            {
                return _graph.GetItemsInDependencyOrder(type);
            }
        }
    }
}