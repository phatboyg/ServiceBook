namespace ServiceBook.Builders
{
    using System.Collections.Generic;
    using Conventions;
    using Registrations;

    public class ContainerBuilderImpl :
        ContainerBuilder
    {
        readonly IList<RegistrationConvention> _registrationConventions;

        public ContainerBuilderImpl()
        {
            _registrationConventions = new List<RegistrationConvention>();
        }

        public Container Build()
        {
            RegistrationConvention convention;
            if (_registrationConventions.Count == 0)
                convention = new ConcreteTypeRegistrationConvention();
            else if (_registrationConventions.Count == 1)
                convention = _registrationConventions[0];
            else
                convention = new MultipleRegistrationConvention(_registrationConventions);

            var serviceBookContainer = new ServiceBookContainer(convention);

            RegistrationCatalog catalog = new ContainerRegistrationCatalog(convention, serviceBookContainer);



            return serviceBookContainer;
        }

        public void AddRegistrationConvention(RegistrationConvention convention)
        {
            _registrationConventions.Add(convention);
        }
    }
}