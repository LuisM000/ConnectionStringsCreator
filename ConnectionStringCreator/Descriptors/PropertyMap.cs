namespace ConnectionStringCreator.Descriptors
{
    public class PropertyMap
    {
        public PropertyMap(object value, object mappedValue)
        {
            this.Value = value;
            this.MappedValue = mappedValue;
        }

        public object Value { get; private set; }
        public object MappedValue { get; private set; }
    }
}
