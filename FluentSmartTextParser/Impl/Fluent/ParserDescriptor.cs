using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;

namespace FluentSmartTextParser.Impl.Fluent
{
    public class ParseDescriptor<T> : IParserDescriptor<T>
    {
        private readonly SmartTextParserContext _context;

        public ParseDescriptor(SmartTextParserContext context)
        {
            _context = context;
        }

        public ParserResult<T> Parse(string file)
        {
            return _context.SmartTextParser.Parse<T>(file, _context.TextSchemaType, _context.SchemaFields, _context.Properties);
        }
    }
}
