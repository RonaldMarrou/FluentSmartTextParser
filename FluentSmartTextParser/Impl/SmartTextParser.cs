using System;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model.Internal;
using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Impl
{
    public class SmartTextParser : ISmartTextParser
    {
        private readonly SmartTextParserContext _context;

        public SmartTextParser(SmartTextParserContext context)
        {
            _context = context;
        }

        public ParserResult<T> Parse<T>()
        {
            throw new NotImplementedException();
        }
    }
}
