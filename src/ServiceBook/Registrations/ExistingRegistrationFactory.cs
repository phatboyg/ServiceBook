namespace ServiceBook.Registrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExistingRegistrationFactory :
        RegistrationFactory,
        RegistrationFactoryCandidate
    {
        readonly Registration _registration;

        public ExistingRegistrationFactory(Registration registration)
        {
            _registration = registration;
        }

        public Type RegistrationType
        {
            get { return _registration.Type; }
        }

        public IEnumerable<RegistrationFactoryCandidate> Candidates
        {
            get { yield return this; }
        }

        public Registration Get()
        {
            return _registration;
        }

        public IEnumerable<RegistrationFactory> Dependencies
        {
            get { return _registration.Dependencies.Select(x => (RegistrationFactory)new ExistingRegistrationFactory(x)); }
        }
    }
}