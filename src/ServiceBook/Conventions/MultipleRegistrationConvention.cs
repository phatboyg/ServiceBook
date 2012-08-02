namespace ServiceBook.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Registrations;

    public class MultipleRegistrationConvention :
        RegistrationConvention
    {
        readonly RegistrationConvention[] _conventions;

        public MultipleRegistrationConvention(IEnumerable<RegistrationConvention> conventions)
        {
            _conventions = conventions.ToArray();
        }

        public MultipleRegistrationConvention(params RegistrationConvention[] conventions)
        {
            _conventions = conventions;
        }

        IEnumerable<RegistrationFactory> RegistrationConvention.GetTypeRegistrations(RegistrationCatalog catalog,
            Type type)
        {
            for (int i = 0; i < _conventions.Length; i++)
            {
                RegistrationFactory[] registrations = _conventions[i].GetTypeRegistrations(catalog, type).ToArray();
                if (registrations.Length > 0)
                    return registrations;
            }

            return Enumerable.Empty<RegistrationFactory>();
        }
    }
}