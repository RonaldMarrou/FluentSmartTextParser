using FluentSmartTextParser.Impl;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSmartTextParser.Test
{
    public class IntegrationTests
    {
        private string _fileLocation;

        [SetUp]
        public void SetUpTest()
        {
            _fileLocation = @"..\..\Files\DelimitedTextFile.txt";
        }

        [Test]
        public void Parse_CheckDelimitedTextFile_ResultReturned()
        {
            var sut = new DelimitedParser(
                    new ISetter[]
                    {
                        new IntegerSetter(),
                        new DecimalSetter(),
                        new StringSetter()
                    }
                );

            var result = sut.Parse<MockedClass>
                (
                    _fileLocation,
                    new Dictionary<string, string>() { { "DelimitedBy", "," } },
                    new List<SmartTextParserProperty>()
                    {
                        new SmartTextParserProperty()
                        {
                            Name = "MockedStringProperty",
                            Required = true,
                            Type = PropertyType.String,
                            MinLenght = 0,
                            MaxLenght = 255,
                            Positions = new Dictionary<string, int> { { "Position", 0 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedIntegerProperty",
                            Required = true,
                            Type = PropertyType.Integer,
                            MinLenght = 0,
                            MaxLenght = 255,
                            Positions = new Dictionary<string, int> { { "Position", 1 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedDecimalProperty",
                            Required = true,
                            Type = PropertyType.Decimal,
                            MinLenght = 0,
                            MaxLenght = 255,
                            Positions = new Dictionary<string, int> { { "Position", 2 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedOptionalStringProperty",
                            Required = false,
                            Type = PropertyType.String,
                            MinLenght = 0,
                            MaxLenght = 255,
                            Positions = new Dictionary<string, int> { { "Position", 3 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedOptionalIntegerProperty",
                            Required = false,
                            Type = PropertyType.Integer,
                            MinLenght = 0,
                            MaxLenght = 255,
                            Positions = new Dictionary<string, int> { { "Position", 4 } }
                        }
                    }
                );

            Assert.AreEqual(8, result.Results.Count);
        }

        [Test]
        public void Parse_CheckDelimitedTextFileWithFluent_ResultReturned()
        {
            var sut = new Impl.FluentSmartTextParser(
                    new SmartTextParser(
                        new ParserFactory(
                            new IParser[]
                            {
                                new DelimitedParser(
                                       new ISetter[]
                                       {
                                           new IntegerSetter(),
                                           new DecimalSetter(),
                                           new StringSetter()
                                       }
                                    )
                            })
                ));

            var result = sut.File(_fileLocation)
                .DelimitedBy(",")
                .AddFirstProperty(PropertyType.String, "MockedStringProperty", 0, 0, 0, true)
                .AddProperty(PropertyType.Integer, "MockedIntegerProperty", 1, 0, 0, true)
                .AddProperty(PropertyType.Decimal, "MockedDecimalProperty", 2, 0, 0, true)
                .AddProperty(PropertyType.String, "MockedOptionalStringProperty", 3, 0, 0, false)
                .AddProperty(PropertyType.Integer, "MockedOptionalIntegerProperty", 4, 0, 0, false)
                .MapTo<MockedClass>()
                .Parse();

            Assert.AreEqual(8, result.Results.Count);
        }
    }

    public class MockedClass
    {
        public string MockedStringProperty { get; set; }

        public int MockedIntegerProperty { get; set; }

        public decimal MockedDecimalProperty { get; set; }

        public string MockedOptionalStringProperty { get; set; }

        public int? MockedOptionalIntegerProperty { get; set; }
    }
}
