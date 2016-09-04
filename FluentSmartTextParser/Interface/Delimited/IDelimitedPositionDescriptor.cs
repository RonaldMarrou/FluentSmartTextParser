using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedPositionDescriptor
    {
        IDelimitedPropertyTypeDescriptor Position(int position);
    }
}
