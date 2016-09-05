using FluentSmartTextParser.Impl;
using Moq;
using NUnit.Framework;

namespace FluentSmartTextParser.Test.Setter
{ 
    [TestFixture]
    public class StringSetterTest
    {
        [TestCase("WHATEVER")]
        [TestCase("269")]
        [TestCase("16416649")]
        [TestCase("1")]
        [TestCase("532653463")]
        [TestCase(null)]
        public void Set_StringIsString_IsSet(string value)
        {
            FooString fooString = new FooString();

            StringSetter sut = new StringSetter();
            var isSet = sut.Set(fooString, "FooProperty", value, null);

            Assert.IsTrue(isSet);
            Assert.AreEqual(value, fooString.FooProperty);            
        }

        [TestCase("245S")]
        [TestCase("235235SFA")]
        [TestCase("SOMERANDOMSTRING")]
        [TestCase("WHATEVER")]
        [TestCase("IMNOTADECIMAL")]
        public void Set_FieldDoesNotExist_IsNotSet(string field)
        {
            FooString fooString = new FooString();

            StringSetter sut = new StringSetter();
            var isSet = sut.Set(fooString, field, "0", null);

            Assert.IsFalse(isSet);
        }
    }

    public class FooString
    {
        public string FooProperty { get; set; }
    }
}
