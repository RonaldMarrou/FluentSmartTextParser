using System;
using System.Linq;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;

namespace FluentSmartTextParser.Impl.Fluent
{
    public class SmartTextParserDescriptor : IDescriptor, IDelimitedDescriptor, IDelimitedPropertyDescriptor, IPositionalDescriptor, IPositionalPropertyDescriptor
    {
        private readonly SmartTextParserContext _context;

        public SmartTextParserDescriptor(string file)
        {
            _context = new SmartTextParserContext()
            {
                File = file
            };
        }

        #region Delimited Properties

        public IDelimitedPropertyDescriptor AddFirstDecimalProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddDelimitedProperty(PropertyType.Decimal, name, position, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IDelimitedPropertyDescriptor AddFirstIntegerProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddDelimitedProperty(PropertyType.Integer, name, position, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IDelimitedPropertyDescriptor AddFirstStringProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddDelimitedProperty(PropertyType.String, name, position, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IDelimitedPropertyDescriptor AddDecimalProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddDelimitedProperty(PropertyType.Decimal, name, position, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IDelimitedPropertyDescriptor AddIntegerProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddDelimitedProperty(PropertyType.Integer, name, position, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IDelimitedPropertyDescriptor AddStringProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddDelimitedProperty(PropertyType.String, name, position, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IDelimitedDescriptor DelimitedBy(string delimitedBy)
        {
            if (string.IsNullOrEmpty(delimitedBy))
            {
                throw new ArgumentNullException(nameof(delimitedBy));
            }

            _context.SchemaType = TextSchemaType.DelimitedByString;

            return this;
        }

        #endregion

        #region Positional Properties

        public IPositionalPropertyDescriptor AddFirstDecimalProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddPositionProperty(PropertyType.Decimal, name, startPosition, endPosition, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IPositionalPropertyDescriptor AddFirstIntegerProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddPositionProperty(PropertyType.Integer, name, startPosition, endPosition, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IPositionalPropertyDescriptor AddFirstStringProperty(string name, int startPosition, int endPosition, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddPositionProperty(PropertyType.String, name, startPosition, endPosition, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IPositionalPropertyDescriptor AddDecimalProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddPositionProperty(PropertyType.Decimal, name, startPosition, endPosition, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IPositionalPropertyDescriptor AddIntegerProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddPositionProperty(PropertyType.Integer, name, startPosition, endPosition, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IPositionalPropertyDescriptor AddStringProperty(string name, int startPosition, int endPosition, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            AddPositionProperty(PropertyType.String, name, startPosition, endPosition, minLenght, maxLenght, extraValidationMethod, required);

            return this;
        }

        public IPositionalDescriptor Positional()
        {
            _context.SchemaType = TextSchemaType.Positional;

            return this;
        }

        #endregion

        #region Add Properties

        private void AddDelimitedProperty(PropertyType type, string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (_context.DelimitedProperties.Any(x => x.Name.Equals(name)))
            {
                throw new InvalidOperationException($"Property {name} can not be added more than once");
            }

            _context.DelimitedProperties.Add(new SmartTextParserDelimitedProperty()
            {
                Type = PropertyType.Decimal,
                Name = name,
                Position = position,
                MinLenght = minLenght,
                MaxLenght = maxLenght,
                ExtraValidationMethod = extraValidationMethod,
                Required = required
            });
        }

        private void AddPositionProperty(PropertyType type, string name, int startPosition, int endPosition, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (_context.DelimitedProperties.Any(x => x.Name.Equals(name)))
            {
                throw new InvalidOperationException($"Property {name} can not be added more than once");
            }

            if (startPosition >= endPosition)
            {
                throw new InvalidOperationException($"Start Position can not be greather or equal than End Position: Start Position={startPosition}, End Position={endPosition}");
            }

            _context.PositionProperties.Add(new SmartTextParserPositionProperty()
            {
                Type = type,
                Name = name,
                StartPosition = startPosition,
                EndPosition = endPosition,
                MinLenght = minLenght,
                MaxLenght = maxLenght,
                ExtraValidationMethod = extraValidationMethod,
                Required = required
            });
        }

        public IParseDescriptor<T> MapTo<T>()
        {
            return new ParseDescriptor<T>(_context);
        }

        #endregion
    }
}
