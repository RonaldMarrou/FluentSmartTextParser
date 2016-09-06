namespace FluentSmartTextParser.Interface.Positional
{
    public interface IPositionalPropertyDescriptor
    {
        IPositionalStartPositionDescriptor AddProperty(string name);

        IPositionalPropertyDescriptor Required(bool required);

        IParserDescriptor<T> MapTo<T>();
    }
}
