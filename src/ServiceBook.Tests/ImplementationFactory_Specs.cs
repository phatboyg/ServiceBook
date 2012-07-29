namespace ServiceBook.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture, Explicit("Not yet written")]
    public class Getting_an_interface_that_meets_dto_standards
    {
        [Test]
        public void Should_return_a_dynamically_generated_backing_store()
        {
            // register in container
            // get from container

            // the trick will be the sources from which the properties will be pulled.
            // each property will have a Factory<T> assigned to it.
            // which may be a dictionary read or whatever

        }

        interface MyView
        {
            Guid Id { get; }
            string Name { get; }
            decimal Amount { get; }
            DateTime LastModified { get; }
            MySubView SubView { get; }
        }

        interface MySubView
        {
            int Id { get; }
        }
    }
}
