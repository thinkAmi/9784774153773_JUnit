using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch18.ex01;

namespace test.ch18.ex01
{
    public class StringUtilsTest
    {
        [TestFixture]
        public class ラムダ式を使うメソッド
        {
            [Test]
            public void ToSnakeCaseはスネークケースを返す_aaaの場合()
            {
                Assert.That(StringUtils.ToSnakeCase("aaa"), Is.EqualTo("aaa"));
            }

            [Test]
            public void ToSnakeCaseはスネークケースを返す_HelloWorldの場合()
            {
                Assert.That(StringUtils.ToSnakeCase("HelloWorld"), Is.EqualTo("hello_world"));
            }

            [Test]
            public void ToSnakeCaseはスネークケースを返す_practiceJunitの場合()
            {
                Assert.That(StringUtils.ToSnakeCase("practiceJunit"), Is.EqualTo("practice_junit"));
            }
        }


        [TestFixture]
        public class ラムダ式を使わないメソッド
        {
            [Test]
            public void ToSnakeCaseWithoutLambdaはスネークケースを返す_aaaの場合()
            {
                Assert.That(StringUtils.ToSnakeCaseWithoutLambda("aaa"), Is.EqualTo("aaa"));
            }

            [Test]
            public void ToSnakeCaseWithoutLambdaはスネークケースを返す_HelloWorldの場合()
            {
                Assert.That(StringUtils.ToSnakeCaseWithoutLambda("HelloWorld"), Is.EqualTo("hello_world"));
            }

            [Test]
            public void ToSnakeCaseWithoutLambdaはスネークケースを返す_practiceJunitの場合()
            {
                Assert.That(StringUtils.ToSnakeCaseWithoutLambda("practiceJunit"), Is.EqualTo("practice_junit"));
            }
        }
    }
}
