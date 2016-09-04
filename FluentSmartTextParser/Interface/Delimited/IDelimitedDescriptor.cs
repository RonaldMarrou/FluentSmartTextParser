using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedDescriptor
    {
        IDelimitedPositionDescriptor AddProperty(string name);
    }
}
