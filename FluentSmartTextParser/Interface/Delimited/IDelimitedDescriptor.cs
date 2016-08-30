using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedDescriptor
    {
        IDelimitedPropertyDescriptor AddFirstProperty(PropertyType type, string name, int position, int minLenght, int maxLenght, bool required = false);
    }
}
