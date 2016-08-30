using FluentSmartTextParser.Interface.Delimited;
using FluentSmartTextParser.Interface.Positional;

namespace FluentSmartTextParser.Interface
{
    public interface IDescriptor
    {
        IPositionalDescriptor Positional();

        IDelimitedDescriptor DelimitedBy(string delimitedBy);
    }
}
