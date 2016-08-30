using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using System.Collections.Generic;

namespace FluentSmartTextParser.Interface
{
    public interface IParser
    {
        ParserResult<T> Parse<T>(string file, Dictionary<string, string> schemaFields, List<SmartTextParserProperty> properties);

        TextSchemaType GetType();
    }
}
