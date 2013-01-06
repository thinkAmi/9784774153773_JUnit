using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch19.ex01;

namespace test.ch19.ex01
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        public void CreateFizzBuzzで16まで取得できる()
        {
            List<string> actual = FizzBuzz.CreateFizzBuzzList(16);
            Assert.That(actual, Is.Not.Null);

            Assert.That(actual[0], Is.EqualTo("1"));
            Assert.That(actual[1], Is.EqualTo("2"));
            Assert.That(actual[2], Is.EqualTo("Fizz"));
            Assert.That(actual[3], Is.EqualTo("4"));
            Assert.That(actual[4], Is.EqualTo("Buzz"));
            Assert.That(actual[5], Is.EqualTo("Fizz"));
            Assert.That(actual[6], Is.EqualTo("7"));
            Assert.That(actual[7], Is.EqualTo("8"));
            Assert.That(actual[8], Is.EqualTo("Fizz"));
            Assert.That(actual[9], Is.EqualTo("Buzz"));
            Assert.That(actual[10], Is.EqualTo("11"));
            Assert.That(actual[11], Is.EqualTo("Fizz"));
            Assert.That(actual[12], Is.EqualTo("13"));
            Assert.That(actual[13], Is.EqualTo("14"));
            Assert.That(actual[14], Is.EqualTo("FizzBuzz"));
            Assert.That(actual[15], Is.EqualTo("16"));
        }

        [Test]
        public void CreateFizzBuzzで6まで取得できる()
        {
            List<string> actual = FizzBuzz.CreateFizzBuzzList(6);
            Assert.That(actual, Lists.List("1", "2", "Fizz", "4", "Buzz", "Fizz"));
        }
    }
}
