using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface
{
    public interface IParserFactory
    {
        IParser Get(TextSchemaType textSchemaType);
    }
}
