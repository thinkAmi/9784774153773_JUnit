using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch20.ex02;
using Rhino.Mocks;      // ターゲットは4.0 (Not ClientProfile)で動作
using NSubstitute;



namespace test.ch20.ex02
{
    public class LogAnalyzerTest
    {
        [TestFixture]
        public class RhinoMocks版
        {
            [Test]
            public void LogLoaderが例外を送出するときAnalyzeExceptionが再送出される()
            {
                //  スタブの動きを指定してあげる
                //See: http://wrightthisblog.blogspot.jp/2011/03/using-rhinomocks-quick-guide-to.html
                var stub = MockRepository.GenerateMock<ILogLoader>();
                stub.Stub(p => p.Load("test")).Throw(new System.IO.IOException("hoge"));

                //  スタブを渡す
                LogAnalyzer sut = new LogAnalyzer(stub);


                Assert.That(() => sut.Analyze("test"), Throws.Exception.TypeOf<AnalyzeException>()
                    .And
                    .Message.EqualTo("hoge")
                    .And
                    .InnerException.TypeOf<System.IO.IOException>()

                    //  試しに、違う例外を指定してあげると、レッドになることを確認
                    //.InnerException.TypeOf<System.IO.DirectoryNotFoundException>() // -> OK:違う例外と認識される
                    );
            }
        }

        [TestFixture]
        public class NSubstitute版
        {
            [Test]
            public void LogLoaderが例外を送出するときAnalyzeExceptionが再送出される()
            {
                var stub = Substitute.For<ILogLoader>();
                stub.When(x => x.Load("test"))
                    .Do(x => { throw new System.IO.IOException("hoge"); });

                LogAnalyzer sut = new LogAnalyzer(stub);


                Assert.That(() => sut.Analyze("test"), Throws.Exception.TypeOf<AnalyzeException>()
                    .And
                    .Message.EqualTo("hoge")
                    .And
                    .InnerException.TypeOf<System.IO.IOException>()

                    //  試しに、違う例外を指定してあげると、レッドになることを確認
                    //  ただし、Rhino.Mocks よりエラーメッセージが分かりにくい
                    //  エラーが途中で切られているような感じ
                    //  結果が長すぎるのかな...
                    //.InnerException.TypeOf<System.IO.DirectoryNotFoundException>() // -> OK:違う例外と認識される
                    );
            }
        }
    }
}
