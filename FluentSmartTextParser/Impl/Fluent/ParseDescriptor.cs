using FluentSmartTextParser.Interface;
using System;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;

namespace FluentSmartTextParser.Impl.Fluent
{
    public class ParseDescriptor<T> : IParseDescriptor<T>
    {
        private readonly SmartTextParserContext _context;

        public ParseDescriptor(SmartTextParserContext context)
        {
            _context = context;
        }

        public ParseResult<T> Parse()
        {
            throw new NotImplementedException();
        }
    }
}
