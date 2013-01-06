using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch20.ex04;
using Rhino.Mocks;
using NSubstitute;

namespace test.ch20.ex04
{
    public class AuthenticationTest
    {
        public class RhinoMocks版
        {
            [TestFixture]
            public class アカウントが存在しない場合
            {
                Authentication sut;

                [SetUp]
                public void SetUp()
                {
                    var stub = MockRepository.GenerateMock<IAccountDao>();
                    stub.Stub(p => p.FindOrNull("user001")).Return(null);

                    sut = new Authentication(stub);
                }

                [Test]
                public void Authenticateはnullを返す()
                {
                    Assert.That(sut.Authenticate("user001", "pw123"), Is.Null);
                }
            }


            [TestFixture]
            public class アカウントが存在しパスワードが一致する場合
            {
                Authentication sut;
                Account account;

                [SetUp]
                public void SetUp()
                {
                    account = new Account("user001", "pw123");

                    var stub = MockRepository.GenerateMock<IAccountDao>();
                    stub.Stub(p => p.FindOrNull("user001")).Return(account);

                    sut = new Authentication(stub);
                }

                [Test]
                public void Authenticateはaccountを返す()
                {
                    Assert.That(sut.Authenticate("user001", "pw123"), Is.SameAs(account));
                }
            }

            [TestFixture]
            public class アカウントが存在するがパスワードが一致しない場合
            {
                Authentication sut;
                Account account;

                [SetUp]
                public void SetUp()
                {
                    account = new Account("user001", "pw999");

                    var stub = MockRepository.GenerateMock<IAccountDao>();
                    stub.Stub(p => p.FindOrNull("user001")).Return(account);

                    sut = new Authentication(stub);
                }

                [Test]
                public void Authenticateはnullを返す()
                {
                    Assert.That(sut.Authenticate("user001", "pw123"), Is.Null);
                }
            }
        }


        public class NSubstitute版
        {
            [TestFixture]
            public class アカウントが存在しない場合
            {
                Authentication sut;

                [SetUp]
                public void SetUp()
                {
                    var stub = Substitute.For<IAccountDao>();
                    stub.FindOrNull("user001").Returns(x => null);
                    sut = new Authentication(stub);
                }

                [Test]
                public void Authenticateはnullを返す()
                {
                    Assert.That(sut.Authenticate("user001", "pw123"), Is.Null);
                }
            }


            [TestFixture]
            public class アカウントが存在しパスワードが一致する場合
            {
                Authentication sut;
                Account account;

                [SetUp]
                public void SetUp()
                {
                    account = new Account("user001", "pw123");

                    var stub = Substitute.For<IAccountDao>();
                    stub.FindOrNull("user001").Returns(account);

                    sut = new Authentication(stub);
                }

                [Test]
                public void Authenticateはaccountを返す()
                {
                    Assert.That(sut.Authenticate("user001", "pw123"), Is.SameAs(account));
                }
            }

            [TestFixture]
            public class アカウントが存在するがパスワードが一致しない場合
            {
                Authentication sut;
                Account account;

                [SetUp]
                public void SetUp()
                {
                    account = new Account("user001", "pw999");

                    var stub = Substitute.For<IAccountDao>();
                    stub.FindOrNull("user001").Returns(account);

                    sut = new Authentication(stub);
                }

                [Test]
                public void Authenticateはnullを返す()
                {
                    Assert.That(sut.Authenticate("user001", "pw123"), Is.Null);
                }
            }
        }
    }
}
