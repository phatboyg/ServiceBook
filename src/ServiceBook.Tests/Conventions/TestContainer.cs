namespace ServiceBook.Tests.Conventions
{
    using System;
    using System.Collections.Generic;
    using Registrations;

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