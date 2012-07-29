namespace ServiceBook.Configurators
{
    using System;

    [Serializable]
    public class ValidateConfigurationResultImpl :
        ValidateConfigurationResult
    {
        public ValidateConfigurationResultImpl(ValidateConfigurationDisposition disposition, string key, string value,
            string message)
        {
            Disposition = disposition;
            Key = key;
            Value = value;
            Message = message;
        }

        public ValidateConfigurationResultImpl(ValidateConfigurationDisposition disposition, string key, string message)
        {
            Disposition = disposition;
            Key = key;
            Message = message;
        }

        public ValidateConfigurationResultImpl(ValidateConfigurationDisposition disposition, string message)
        {
            Key = "";
            Disposition = disposition;
            Message = message;
        }

        public ValidateConfigurationDisposition Disposition { get; private set; }
        public string Key { get; private set; }
        public string Value { get; set; }
        public string Message { get; private set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Disposition, string.IsNullOrEmpty(Key)
                                                               ? Message
                                                               : Key + " " + Message);
        }
    }
}