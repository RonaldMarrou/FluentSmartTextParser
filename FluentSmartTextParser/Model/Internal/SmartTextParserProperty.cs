using System.Collections.Generic;

namespace FluentSmartTextParser.Model.Internal
{
    public class SmartTextParserProperty
    {
        public PropertyType Type { get; set; }

        public string Name { get; set; }

        public int MinLenght { get; set; }

        public int MaxLenght { get; set; }

        public bool Required { get; set; }

        public Dictionary<string, int> Positions { get; set; }
    }
}
