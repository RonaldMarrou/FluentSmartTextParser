using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedPositionDescriptor
    {
        IDelimitedPropertyDescriptor Position(int position);
    }
}
