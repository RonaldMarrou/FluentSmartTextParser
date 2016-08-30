using System;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model.Internal;
using FluentSmartTextParser.Model;
using System.Collections.Generic;

namespace FluentSmartTextParser.Impl
{
    public class SmartTextParser : ISmartTextParser
    {
        public ParserResult<T> Parse<T>(string file, Dictionary<string, string> schemaFields, List<SmartTextParserProperty> properties)
        {
            throw new NotImplementedException();
        }
    }
}
