using Moq;
using FluentSmartTextParser.Interface;
using NUnit.Framework;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Impl;

namespace FluentSmartTextParser.Test.Factory
{
    public class ParserFactoryTest
    {
        [TestCase(TextSchemaType.DelimitedByString)]
        [TestCase(TextSchemaType.Positional)]
        public void Get_SetType_TypeFound(TextSchemaType textSchemaType)
        {
            var parser = new Mock<IParser>();
            parser.Setup(x => x.GetSchemaType()).Returns(textSchemaType);

            var sut = new ParserFactory(new IParser[] { parser.Object });

            Assert.AreEqual(textSchemaType, sut.Get(textSchemaType).GetSchemaType());
        }
    }
}
