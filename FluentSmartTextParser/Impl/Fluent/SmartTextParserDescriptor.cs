using System;
using System.Linq;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using FluentSmartTextParser.Interface.Delimited;
using FluentSmartTextParser.Interface.Positional;
using System.Collections.Generic;

namespace FluentSmartTextParser.Impl.Fluent
{
    public class SmartTextParserDescriptor : IDescriptor, IDelimitedDescriptor, IDelimitedPositionDescriptor, IDelimitedPropertyDescriptor, IPositionalDescriptor, IPositionalPropertyDescriptor
    {
        private readonly SmartTextParserContext _context;

        public SmartTextParserDescriptor(string file, ISmartTextParser smartTextParser)
        {
            _context = new SmartTextParserContext(smartTextParser)
            {
                File = file
            };
        }

        #region Properties

        public IDelimitedPropertyDescriptor Required(bool required)
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Required = required;

            return this;
        }

        public IDelimitedPropertyDescriptor Position(int position)
        {
            var lastProperty = _context.Properties.Last();

            if (!lastProperty.Positions.Any(f => f.Key.Equals("Position")))
            {
                lastProperty.Positions.Add("Position", position);
            }

            return this;
        }

        public IDelimitedPropertyDescriptor MinimumLenght(int minimumLenght)
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.MinLenght = minimumLenght;

            return this;
        }

        public IDelimitedPropertyDescriptor MaximumLenght(int maximumLenght)
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.MaxLenght = maximumLenght;

            return this;
        }

        #endregion

        #region Positional Properties

        public IPositionalPropertyDescriptor AddProperty(PropertyType type, string name, int startPosition, int endPosition, int minLenght, int maxLenght, bool required = false)
        {
            AddPositionProperty(type, name, startPosition, endPosition, minLenght, maxLenght, required);

            return this;
        }

        private void AddPositionProperty(PropertyType type, string name, int startPosition, int endPosition, int minLenght, int maxLenght, bool required = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (_context.Properties.Any(x => x.Name.Equals(name)))
            {
                throw new InvalidOperationException($"Property {name} can not be added more than once");
            }

            if (startPosition >= endPosition)
            {
                throw new InvalidOperationException($"Start Position can not be greather or equal than End Position: Start Position={startPosition}, End Position={endPosition}");
            }

            var property = new SmartTextParserProperty()
            {
                Type = type,
                Name = name,
                Positions = new Dictionary<string, int> ()
                {
                    { "StartPosition", startPosition },
                    { "EndPosition", endPosition }
                },
                MinLenght = minLenght,
                MaxLenght = maxLenght,
                Required = required
            };

            _context.Properties.Add(property);
        }


        #endregion

        #region Delimited Properties

        public IDelimitedPositionDescriptor AddProperty(PropertyType type, string name)
        {
            AddDelimitedProperty(type, name);

            return this;
        }

        private void AddDelimitedProperty(PropertyType type, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (_context.Properties.Any(x => x.Name.Equals(name)))
            {
                throw new InvalidOperationException($"Property {name} can not be added more than once");
            }

            var property = new SmartTextParserProperty()
            {
                Type = type,
                Name = name
            };

            _context.Properties.Add(property);
        }

        #endregion

        #region Schema

        public IDelimitedDescriptor DelimitedBy(string delimitedBy)
        {
            if (string.IsNullOrEmpty(delimitedBy))
            {
                throw new ArgumentNullException(nameof(delimitedBy));
            }

            _context.TextSchemaType = TextSchemaType.DelimitedByString;
            _context.SchemaFields.Add("DelimitedBy", delimitedBy);

            return this;
        }

        public IPositionalDescriptor Positional()
        {
            _context.TextSchemaType = TextSchemaType.Positional;

            return this;
        }

        #endregion

        #region Map

        public IParserDescriptor<T> MapTo<T>()
        {
            return new ParseDescriptor<T>(_context);
        }

        #endregion
    }
}
