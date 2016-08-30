using System;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model.Internal;
using FluentSmartTextParser.Model;
using System.Collections.Generic;

namespace FluentSmartTextParser.Impl
{
    public class SmartTextParser : ISmartTextParser
    {
        private readonly IParserFactory _parserFactory;

        public SmartTextParser(IParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public ParserResult<T> Parse<T>(string file, TextSchemaType textSchemaType, Dictionary<string, string> schemaFields, List<SmartTextParserProperty> properties)
        {
            return _parserFactory.Get(textSchemaType).Parse<T>(file, schemaFields, properties);
        }
    }
}
