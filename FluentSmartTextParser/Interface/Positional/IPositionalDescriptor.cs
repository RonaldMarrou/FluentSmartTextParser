using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Positional
{
    public interface IPositionalDescriptor
    {
        IPositionalPropertyDescriptor AddFirstProperty(PropertyType type, string name, int startPosition, int endPosition, int minLenght, int maxLenght, bool required = false);
    }
}
