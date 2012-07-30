namespace ServiceBook.Builders
{
    using System.Collections.Generic;
    using Conventions;

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

            return new ServiceBookContainer(convention);
        }

        public void AddRegistrationConvention(RegistrationConvention convention)
        {
            _registrationConventions.Add(convention);
        }
    }
}