using FluentSmartTextParser.Impl;
using NUnit.Framework;
using System;

namespace FluentSmartTextParser.Test.Setter
{
    public class DateTimeSetterTest
    {
        [Test]
        public void Set_StringIsDateTime_IsSet()
        {
            FooDateTime fooDateTime = new FooDateTime();

            DateTimeSetter sut = new DateTimeSetter();
            var isSet = sut.Set(fooDateTime, "FooProperty", "2016/04/05", null);

            Assert.IsTrue(isSet);
            Assert.AreEqual(new DateTime(2016, 04, 05), fooDateTime.FooProperty);
        }

        [Test]
        public void Set_StringIsNotDateTime_IsNotSet()
        {
            FooDateTime fooDateTime = new FooDateTime();

            DateTimeSetter sut = new DateTimeSetter();
            var isSet = sut.Set(fooDateTime, "FooProperty", "NotADateTimeString", null);

            Assert.IsFalse(isSet);
        }

        [Test]
        public void Set_StringIsDateTimeWithFormat_IsSet()
        {
            FooDateTime fooDateTime = new FooDateTime();

            DateTimeSetter sut = new DateTimeSetter();
            var isSet = sut.Set(fooDateTime, "FooProperty", "09-04-2016", new System.Collections.Generic.Dictionary<string, string>() { { "DateTimeFormat", "MM-dd-yyyy" } });

            Assert.IsTrue(isSet);
            Assert.AreEqual(new DateTime(2016, 09, 04), fooDateTime.FooProperty);
        }

        [Test]
        public void Set_StringIsNotDateTimeWithFormat_IsNotSet()
        {
            FooDateTime fooDateTime = new FooDateTime();

            DateTimeSetter sut = new DateTimeSetter();
            var isSet = sut.Set(fooDateTime, "FooProperty", "NotADateTimeString", new System.Collections.Generic.Dictionary<string, string>() { { "DateTimeFormat", "MM-dd-yyyy" } });

            Assert.IsFalse(isSet);
        }

        [Test]
        public void Set_StringIsNotDateTimeWithWrongFormat_IsNotSet()
        {
            FooDateTime fooDateTime = new FooDateTime();

            DateTimeSetter sut = new DateTimeSetter();
            var isSet = sut.Set(fooDateTime, "FooProperty", "09-04-2016", new System.Collections.Generic.Dictionary<string, string>() { { "DateTimeFormat", "ImAWrongFormat" } });

            Assert.IsFalse(isSet);
        }
    }

    public class FooDateTime
    {
        public DateTime FooProperty { get; set; }
    }
}
