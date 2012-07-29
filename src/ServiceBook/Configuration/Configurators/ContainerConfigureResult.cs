namespace ServiceBook.Configurators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class ContainerConfigureResult :
        ConfigureResult
    {
        readonly IList<ValidateConfigurationResult> _results;

        public ContainerConfigureResult(IEnumerable<ValidateConfigurationResult> results)
        {
            _results = results.ToList();
        }

        public bool ContainsFailure
        {
            get { return _results.Any(x => x.Disposition == ValidateConfigurationDisposition.Failure); }
        }

        public IEnumerable<ValidateConfigurationResult> Results
        {
            get { return _results; }
        }
    }
}