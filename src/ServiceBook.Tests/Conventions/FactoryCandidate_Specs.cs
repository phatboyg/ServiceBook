namespace ServiceBook.Tests.Conventions
{
    using System.Linq;
    using NUnit.Framework;
    using Registrations;

    [TestFixture]
    public class FactoryCandidate_Specs
    {
        [Test]
        public void FirstTestName()
        {
            FactoryCandidate[] candidates = typeof(A).GetConstructors()
                .Select(x => x.GetFactoryCandidate()).ToArray();

            Assert.AreEqual(2, candidates.Length);

            Assert.AreEqual(typeof(B), candidates[0].Dependencies.First().DependencyType);
            Assert.AreEqual(typeof(C), candidates[1].Dependencies.First().DependencyType);
        }

        class A
        {
            public A(B b)
            {
            }

            public A(C c)
            {
            }
        }

        class B
        {
        }

        class C
        {
        }
    }
}