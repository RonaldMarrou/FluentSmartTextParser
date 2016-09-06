using System.Collections.Generic;

namespace FluentSmartTextParser.Model.Internal
{
    public class SmartTextParserProperty
    {
        public SmartTextParserProperty()
        {
            Positions = new Dictionary<string, int>();

            Custom = new Dictionary<string, string>();
        }

        public PropertyType Type { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public Dictionary<string, int> Positions { get; set; }

        public Dictionary<string, string> Custom { get; set; }
    }
}
