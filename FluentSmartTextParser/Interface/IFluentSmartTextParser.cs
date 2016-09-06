using FluentSmartTextParser.Interface.Delimited;

namespace FluentSmartTextParser.Interface
{
    public interface IFluentSmartTextParser
    {
        IDelimitedDescriptor DelimitedBy(string delimitedBy);
    }
}
