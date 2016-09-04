using FluentSmartTextParser.Impl;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace FluentSmartTextParser.Test.Parser
{
    public class BaseParserTest : BaseParser
    {
        private PropertyInfo[] _propertyInfoList;

        [SetUp]
        public void SetUpTest()
        {
            _propertyInfoList = typeof(FooClass).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        [Test]
        public void GetMetadataErrorList_NonExistantPropertyNamesOnClass_ErrorReturned()
        {
            var smartTextParserProperties = new List<SmartTextParserProperty>()
            {
                new SmartTextParserProperty()
                {
                    Name = "Integer1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableInteger1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NonExistantProperty1",
                    Type = PropertyType.Integer,
                },
                new SmartTextParserProperty()
                {
                    Name = "NonExistantProperty2",
                    Type = PropertyType.Integer,
                },
                new SmartTextParserProperty()
                {
                    Name = "NonExistantProperty3",
                    Type = PropertyType.Integer
                }
            };

            var sut = new MockedParser();

            var result = sut.MockedMethod(_propertyInfoList, smartTextParserProperties, It.IsAny<string>());

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void GetMetadataErrorList_NoMatchingPropertyTypesOnClass_ErrorReturned()
        {
            var smartTextParserProperties = new List<SmartTextParserProperty>()
            {
                new SmartTextParserProperty()
                {
                    Name = "Integer1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableInteger1",
                    Type = PropertyType.Integer,
                    Required = false
                },
                new SmartTextParserProperty()
                {
                    Name = "String1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "Decimal1",
                    Type = PropertyType.Decimal,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableDecimal1",
                    Type = PropertyType.Integer,
                    Required = false
                }
            };

            var sut = new MockedParser();

            var result = sut.MockedMethod(_propertyInfoList, smartTextParserProperties, It.IsAny<string>());

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetMetadataErrorList_NoMatchingPropertyTypesAndNonExistantPropertiesOnClass_ErrorReturned()
        {
            var smartTextParserProperties = new List<SmartTextParserProperty>()
            {
                new SmartTextParserProperty()
                {
                    Name = "Integer1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableInteger1",
                    Type = PropertyType.Integer,
                    Required = false
                },
                new SmartTextParserProperty()
                {
                    Name = "String1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "Decimal1",
                    Type = PropertyType.Decimal,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableDecimal1",
                    Type = PropertyType.Integer,
                    Required = false
                },
                new SmartTextParserProperty()
                {
                    Name = "NonExistantProperty1",
                    Type = PropertyType.Integer
                },
                new SmartTextParserProperty()
                {
                    Name = "NonExistantProperty2",
                    Type = PropertyType.Integer
                }
            };

            var sut = new MockedParser();

            var result = sut.MockedMethod(_propertyInfoList, smartTextParserProperties, It.IsAny<string>());

            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void GetMetadataErrorList_NotRequiredPropertiesAreNotNullableProperties_ErrorReturned()
        {
            var smartTextParserProperties = new List<SmartTextParserProperty>()
            {
                new SmartTextParserProperty()
                {
                    Name = "Integer1",
                    Type = PropertyType.Integer,
                    Required = false
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableInteger1",
                    Type = PropertyType.Integer,
                    Required = false
                },
                new SmartTextParserProperty()
                {
                    Name = "String1",
                    Type = PropertyType.String,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "Decimal1",
                    Type = PropertyType.Decimal,
                    Required = false
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableDecimal1",
                    Type = PropertyType.Decimal,
                    Required = false
                }
            };

            var sut = new MockedParser();

            var result = sut.MockedMethod(_propertyInfoList, smartTextParserProperties, It.IsAny<string>());

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetMetadataErrorList_RequiredPropertiesSet_NoErrorReturned()
        {
            var smartTextParserProperties = new List<SmartTextParserProperty>()
            {
                new SmartTextParserProperty()
                {
                    Name = "Integer1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableInteger1",
                    Type = PropertyType.Integer,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "String1",
                    Type = PropertyType.String,
                    Required = false
                },
                new SmartTextParserProperty()
                {
                    Name = "Decimal1",
                    Type = PropertyType.Decimal,
                    Required = true
                },
                new SmartTextParserProperty()
                {
                    Name = "NullableDecimal1",
                    Type = PropertyType.Decimal,
                    Required = false
                }
            };

            var sut = new MockedParser();

            var result = sut.MockedMethod(_propertyInfoList, smartTextParserProperties, It.IsAny<string>());

            Assert.AreEqual(0, result.Count);
        }
    }

    public class MockedParser : BaseParser
    {
        public List<ParserError> MockedMethod(PropertyInfo[] propertyInfoList, List<SmartTextParserProperty> properties, string className)
        {
            return GetMetadataErrorList(propertyInfoList, properties, className);
        }
    }

    public class FooClass
    {
        public int Integer1 { get; set; }

        public int? NullableInteger1 { get; set; }

        public string String1 { get; set; }

        public decimal Decimal1 { get; set; }

        public decimal? NullableDecimal1 { get; set; }
    }
}



