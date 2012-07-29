namespace ServiceBook.Builders
{
    public class ContainerBuilderImpl : 
        ContainerBuilder
    {
        public Container Build()
        {
            return new ServiceBookContainer();
        }
    }
}