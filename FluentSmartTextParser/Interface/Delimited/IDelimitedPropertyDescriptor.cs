using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedPropertyDescriptor
    {
        IDelimitedPropertyDescriptor AddProperty(PropertyType type, string name, int position, int minLenght, int maxLenght, bool required = false);

        IParserDescriptor<T> MapTo<T>();
    }
}
