namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedPropertyDescriptor
    {
        IDelimitedPositionDescriptor AddProperty(string name);

        IDelimitedPropertyDescriptor Required(bool required);

        IParserDescriptor<T> MapTo<T>();
    }
}
