using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Interface.Delimited;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using System;
using System.Linq;

namespace FluentSmartTextParser.Impl.Fluent
{
    public class DelimitedDescriptor : IDelimitedDescriptor, IDelimitedPositionDescriptor, IDelimitedPropertyTypeDescriptor, IDelimitedPropertyDescriptor
    {
        private readonly SmartTextParserContext _context;

        public DelimitedDescriptor(ISmartTextParser smartTextParser, string delimitedBy)
        {
            if (string.IsNullOrEmpty(delimitedBy))
            {
                throw new ArgumentNullException(nameof(delimitedBy));
            }

            _context = new SmartTextParserContext(smartTextParser)
            {
                TextSchemaType = TextSchemaType.DelimitedByString
            };

            ;
            _context.SchemaFields.Add("DelimitedBy", delimitedBy);
        }

        #region Property

        public IDelimitedPropertyDescriptor Required(bool required)
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Required = required;

            return this;
        }

        public IDelimitedPropertyTypeDescriptor Position(int position)
        {
            var lastProperty = _context.Properties.Last();

            if (!lastProperty.Positions.Any(f => f.Key.Equals("Position")))
            {
                lastProperty.Positions.Add("Position", position);
            }

            return this;
        }    

        public IDelimitedPositionDescriptor AddProperty(string name)
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

        #endregion

        #region Types

        public IDelimitedPropertyDescriptor Integer()
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Type = PropertyType.Integer;

            return this;
        }

        public IDelimitedPropertyDescriptor Decimal()
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Type = PropertyType.Decimal;

            return this;
        }

        public IDelimitedPropertyDescriptor String()
        {
            var lastProperty = _context.Properties.Last();
            lastProperty.Type = PropertyType.String;

            return this;
        }

        public IDelimitedPropertyDescriptor DateTime(string format = null)
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

        #region Map

        public IParserDescriptor<T> MapTo<T>()
        {
            return new ParseDescriptor<T>(_context);
        }

        #endregion
    }
}
