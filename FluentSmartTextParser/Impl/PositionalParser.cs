using FluentSmartTextParser.Interface;
using System;
using System.Collections.Generic;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;

namespace FluentSmartTextParser.Impl
{
    public class PositionalParser : IParser
    {
        public ParserResult<T> Parse<T>(string file, Dictionary<string, string> schemaFields, List<SmartTextParserProperty> properties)
        {
            throw new NotImplementedException();
        }

        TextSchemaType IParser.GetType()
        {
            return TextSchemaType.Positional;
        }
    }
}
