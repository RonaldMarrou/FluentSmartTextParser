﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSmartTextParser.Model
{
    public class ParserResult<T>
    {
        public ParserResult()
        {
            _errors = new List<ParserError>();
            _results = new List<T>();
        }

        public ParserResultStatus Status { get; set; }

        private List<ParserError> _errors;

        public List<ParserError> Errors
        {
            get { return _errors; }
            private set { _errors = value; }
        }

        private List<T> _results;

        public List<T> Results
        {
            get { return _results; }
            set { _results = value; }
        }

    }
}