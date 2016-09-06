using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Positional
{
    public interface IPositionalDescriptor
    {
        IPositionalStartPositionDescriptor AddProperty(string name);
    }
}
