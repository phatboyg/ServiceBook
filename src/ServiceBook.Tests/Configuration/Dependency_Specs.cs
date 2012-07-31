﻿namespace ServiceBook.Tests.Configuration
{
    using NUnit.Framework;

    [TestFixture]
    public class When_a_class_has_a_dependency
    {
        [Test]
        public void Should_get_1_dependency()
        {
            Container container = ContainerFactory.New(x => { });

            var subject = container.Get<B>();

            Assert.IsNotNull(subject);
            Assert.IsNotNull(subject.A);
        }

        [Test]
        public void Should_get_2_dependencies()
        {
            Container container = ContainerFactory.New(x => { });

            var subject = container.Get<E>();

            Assert.IsNotNull(subject);
            Assert.IsNotNull(subject.A);
            Assert.IsNotNull(subject.D);
        }

        [Test]
        public void Should_get_3_dependencies()
        {
            Container container = ContainerFactory.New(x => { });

            var subject = container.Get<F>();

            Assert.IsNotNull(subject);
            Assert.IsNotNull(subject.A);
            Assert.IsNotNull(subject.B);
            Assert.IsNotNull(subject.C);
        }

        [Test]
        public void Should_get_4_dependencies()
        {
            Container container = ContainerFactory.New(x => { });

            var subject = container.Get<G>();

            Assert.IsNotNull(subject);
            Assert.IsNotNull(subject.A);
            Assert.IsNotNull(subject.B);
            Assert.IsNotNull(subject.C);
            Assert.IsNotNull(subject.D);
        }

        [Test]
        public void Should_get_dependencies_of_dependencies()
        {
            Container container = ContainerFactory.New(x => { });

            var subject = container.Get<C>();

            Assert.IsNotNull(subject);
            Assert.IsNotNull(subject.B);
            Assert.IsNotNull(subject.B.A);
        }

        class A
        {
        }

        class B
        {
            public B(A a)
            {
                A = a;
            }

            public A A { get; private set; }
        }

        class C
        {
            public C(B b)
            {
                B = b;
            }

            public B B { get; private set; }
        }

        class D
        {
        }

        class E
        {
            public E(A a, D d)
            {
                A = a;
                D = d;
            }

            public A A { get; private set; }
            public D D { get; private set; }
        }

        class F
        {
            public A A { get; private set; }
            public B B { get; private set; }
            public C C { get; private set; }

            public F(A a, B b, C c)
            {
                A = a;
                B = b;
                C = c;
            }
        }

        class G
        {
            public A A { get; private set; }
            public B B { get; private set; }
            public C C { get; private set; }
            public D D { get; private set; }

            public G(A a, B b, C c, D d)
            {
                A = a;
                B = b;
                C = c;
                D = d;
            }
        }
    }
}