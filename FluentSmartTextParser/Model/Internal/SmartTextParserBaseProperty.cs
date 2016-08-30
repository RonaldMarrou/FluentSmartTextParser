using System;

namespace FluentSmartTextParser.Model.Internal
{
    public class SmartTextParserBaseProperty
    {
        public PropertyType Type { get; set; }

        public string Name { get; set; }

        public int MinLenght { get; set; }

        public int MaxLenght { get; set; }

        public bool Required { get; set; }
    }
}
