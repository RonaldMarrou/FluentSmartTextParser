using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Interface.Positional;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using System;
using System.Linq;

namespace FluentSmartTextParser.Impl.Fluent
{
    public class PositionalDescriptor : IPositionalDescriptor, IPositionalPropertyDescriptor, IPositionalStartPositionDescriptor, IPositionalEndPositionDescriptor, IPositionalPropertyTypeDescriptor
    {
        private readonly SmartTextParserContext _context;

        public PositionalDescriptor(ISmartTextParser smartTextParser)
        {
            _context = new SmartTextParserContext(smartTextParser)
            {
                TextSchemaType = TextSchemaType.Positional
            };
        }

        #region Property

        public IPositionalStartPositionDescriptor AddProperty(string name)
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
                Name = name
            };

            _context.Properties.Add(property);

            return this;
        }

        public IPositionalEndPositionDescriptor StartPosition(int startPosition)
        {
            var lastProperty = _context.Properties.Last();

            if (!lastProperty.Positions.Any(f => f.Key.Equals("StartPosition")))
            {
                lastProperty.Positions.Add("StartPosition", startPosition);
            }

            return this;
        }

        public IPositionalPropertyTypeDescriptor EndPosition(int endPosition)
        {
            var lastProperty = _context.Properties.Last();

            if(lastProperty.Positions["StartPosition"] >= endPosition)
            {
                throw new InvalidOperationException($"End Position can not be less or equal than Start Position");
            }

            if (!lastProperty.Positions.Any(f => f.Key.Equals("EndPosition")))
            {
                lastProperty.Positions.Add("EndPosition", endPosition);
            }

            return this;
        }

        #endregion

        #region Types

        public IPositionalPropertyDescriptor Integer()
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Type = PropertyType.Integer;

            return this;
        }

        public IPositionalPropertyDescriptor Decimal()
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Type = PropertyType.Decimal;

            return this;
        }

        public IPositionalPropertyDescriptor String()
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Type = PropertyType.String;

            return this;
        }

        public IPositionalPropertyDescriptor DateTime(string format = null)
        {
            var lastProperty = _context.Properties.Last();

            if (string.IsNullOrEmpty(format))
            {
                lastProperty.Custom.Add("DateTimeFormat", format);
            }

            lastProperty.Type = PropertyType.DateTime;

            return this;
        }

        #endregion

        public IPositionalPropertyDescriptor Required(bool required)
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Required = required;

            return this;
        }

        #region Map

        public IParserDescriptor<T> MapTo<T>()
        {
            return new ParseDescriptor<T>(_context);
        }

        #endregion
    }
}
