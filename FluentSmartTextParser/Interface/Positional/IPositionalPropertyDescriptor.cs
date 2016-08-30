using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Positional
{
    public interface IPositionalPropertyDescriptor
    {
        IPositionalPropertyDescriptor AddProperty(PropertyType type, string name, int startPosition, int endPosition, int minLenght, int maxLenght, bool required = false);

        IParserDescriptor<T> MapTo<T>();
    }
}
