using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch18.ex05;

namespace test.ch18.ex05
{
    public class ItemStockTest
    {
        [TestFixture]
        public class 初期状態の場合
        {
            ItemStock sut;
            Item book;

            [SetUp]
            public void SetUp()
            {
                book = new Item("book", 3800);
                sut = new ItemStock();
            }

            [Test]
            public void GetNumはbookで0を返す()
            {
                Assert.That(sut.GetNum(book), Is.EqualTo(0));
            }

            [Test]
            public void Addでbookを追加するとGetNumで1を返す()
            {
                sut.Add(book);
                Assert.That(sut.GetNum(book), Is.EqualTo(1));
            }

        }

        [TestFixture]
        public class bookが1回追加されている場合
        {
            ItemStock sut;
            Item book;

            [SetUp]
            public void SetUp()
            {
                book = new Item("book", 3800);
                sut = new ItemStock();
                sut.Add(book);
            }

            [Test]
            public void GetNumはbookで1を返す()
            {
                Assert.That(sut.GetNum(book), Is.EqualTo(1));
            }

            [Test]
            public void addでbookを追加するとGetNumで2を返す()
            {
                sut.Add(book);
                Assert.That(sut.GetNum(book), Is.EqualTo(2));
            }

            [Test]
            public void addでbikeを追加するとGetNumでbookとbikeは1を返す()
            {
                Item bike = new Item("bike", 57000);
                sut.Add(bike);

                Assert.That(sut.GetNum(book), Is.EqualTo(1));
                Assert.That(sut.GetNum(bike), Is.EqualTo(1));
            }
        }

    }
}
