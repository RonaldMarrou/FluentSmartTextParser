using FluentSmartTextParser.Impl.Fluent;
using FluentSmartTextParser.Interface;
using System;

namespace FluentSmartTextParser.Impl
{
    public class FluentSmartTextParser : IFluentSmartTextParser
    {
        private readonly ISmartTextParser _smartTextParser;

        public FluentSmartTextParser(ISmartTextParser smartTextParser)
        {
            _smartTextParser = smartTextParser;
        }

        public IDescriptor File(string file)
        {
            return new SmartTextParserDescriptor(file, _smartTextParser);
        }
    }
}
