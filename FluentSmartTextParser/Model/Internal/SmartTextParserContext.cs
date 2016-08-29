using System.Collections.Generic;

namespace FluentSmartTextParser.Model.Internal
{
    public class SmartTextParserContext
    {
        public SmartTextParserContext()
        {
            _delimitedProperties = new List<SmartTextParserDelimitedProperty>();
            _positionProperties = new List<SmartTextParserPositionProperty>();
        }

        public string File { get; set; }

        public TextSchemaType SchemaType { get; set; }

        public string DelimitedBy { get; set; }

        private List<SmartTextParserDelimitedProperty> _delimitedProperties;

        public List<SmartTextParserDelimitedProperty> DelimitedProperties
        {
            get { return _delimitedProperties; }
            private set { _delimitedProperties = value; }
        }

        private List<SmartTextParserPositionProperty> _positionProperties;

        public List<SmartTextParserPositionProperty> PositionProperties
        {
            get { return _positionProperties; }
            private set { _positionProperties = value; }
        }
    }
}
