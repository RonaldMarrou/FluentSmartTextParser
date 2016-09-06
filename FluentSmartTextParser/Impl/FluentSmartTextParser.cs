using FluentSmartTextParser.Impl.Fluent;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Interface.Delimited;
using FluentSmartTextParser.Interface.Positional;

namespace FluentSmartTextParser.Impl
{
    public class FluentSmartTextParser : IFluentSmartTextParser
    {
        private readonly ISmartTextParser _smartTextParser;

        public FluentSmartTextParser(ISmartTextParser smartTextParser)
        {
            _smartTextParser = smartTextParser;
        }

        public IDelimitedDescriptor DelimitedBy(string delimitedBy)
        {
            return new DelimitedDescriptor(_smartTextParser, delimitedBy);
        }

        public IPositionalDescriptor Positional()
        {
            return new PositionalDescriptor(_smartTextParser);
        }
    }
}
