using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedPropertyDescriptor
    {
        IDelimitedPositionDescriptor AddProperty(string name);

        IDelimitedPropertyDescriptor Required(bool required);

        IDelimitedPropertyDescriptor MinimumLenght(int miniumLenght);

        IDelimitedPropertyDescriptor MaximumLenght(int maximumLenght);

        IParserDescriptor<T> MapTo<T>();
    }
}
