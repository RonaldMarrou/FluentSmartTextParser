using FluentSmartTextParser.Interface;
using System.Collections.Generic;

namespace FluentSmartTextParser.Model.Internal
{
    public class SmartTextParserContext
    {
        public SmartTextParserContext(ISmartTextParser smartTextParser)
        {
            SchemaFields = new Dictionary<string, string>();

            Properties = new List<SmartTextParserProperty>();

            SmartTextParser = smartTextParser;
        }

        public ISmartTextParser SmartTextParser { get; set; }

        public string File { get; set; }

        public TextSchemaType TextSchemaType { get; set; }

        public Dictionary<string, string> SchemaFields { get; set; }

        public List<SmartTextParserProperty> Properties { get; set; }
    }
}
