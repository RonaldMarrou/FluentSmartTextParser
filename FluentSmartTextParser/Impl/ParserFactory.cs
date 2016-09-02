using FluentSmartTextParser.Interface;
using System.Linq;
using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Impl
{
    public class ParserFactory : IParserFactory
    {
        private readonly IParser[] _parsers;

        public ParserFactory(IParser[] parsers)
        {
            _parsers = parsers;
        }

        public IParser Get(TextSchemaType textSchemaType)
        {
            return _parsers.First(x => x.GetSchemaType() == textSchemaType);
        }
    }
}
