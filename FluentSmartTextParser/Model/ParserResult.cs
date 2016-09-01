using System.Collections.Generic;

namespace FluentSmartTextParser.Model
{
    public class ParserResult<T>
    {
        public ParserResult()
        {
            Errors = new List<ParserError>();
            Results = new List<T>();
        }

        public ParserResultStatus Status { get; set; }

        public List<ParserError> Errors { get; set; }

        public List<T> Results { get; set; }
    }
}
