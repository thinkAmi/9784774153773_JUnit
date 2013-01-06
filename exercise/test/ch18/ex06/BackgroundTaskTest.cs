using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using production.ch18.ex06;

namespace test.ch18.ex06
{
    public class BackgroundTaskTest
    {
        [TestFixture]
        public class TaskとWaitAllをつかう場合
        {
            static int threadId;

            [Test]
            public void Invokeで別タスクで実行される()
            {
                Task task = new Task(() => threadId = Thread.CurrentThread.ManagedThreadId);
                BackgroundTask sut = new BackgroundTask(task);

                sut.Invoke();
                Task.WaitAll(task);

                Assert.That(threadId, Is.Not.EqualTo(Thread.CurrentThread.ManagedThreadId));
            }
        }



        [TestFixture]
        public class TaskとCountdownEventを使う場合
        {
            static int threadId;

            [Test]
            public void Invokeで別タスクが実行される()
            {
                using (CountdownEvent cde = new CountdownEvent(1))
                {
                    Task task = new Task(() => {
                        threadId = Thread.CurrentThread.ManagedThreadId;
                        cde.Signal();
                    });

                    BackgroundTask sut = new BackgroundTask(task);

                    sut.Invoke();
                    cde.Wait();
                }

                Assert.That(threadId, Is.Not.EqualTo(Thread.CurrentThread.ManagedThreadId));
            }
        }



        [TestFixture]
        public class ThreadとCountdownEventを使う場合
        {
            //  CountdownEventをnew Thread時の引数として渡したいところだが、
            //  ParameterizedThreadStartを使うのはsutのInvokeメソッドを修正する必要があるので、
            //  CountdownEventは外側に出す (Disposeを忘れずに)
            //  See: http://www.albahari.com/threading/part4.aspx#_Writing_a_CountdownEvent

            static int threadId;

            static CountdownEvent cde;

            [SetUp]
            public void SetUp()
            {
                cde = new CountdownEvent(1);
            }

            [Test]
            public void Invokeで別スレッドで実行される()
            {
                Thread task = new Thread(Run);
                BackgroundTaskByThread sut = new BackgroundTaskByThread(task);

                sut.Invoke();
                cde.Wait();

                Assert.That(threadId, Is.Not.EqualTo(Thread.CurrentThread.ManagedThreadId));
            }

            [TearDown]
            public void TearDown()
            {
                cde.Dispose();
            }


            public static void Run()
            {
                threadId = Thread.CurrentThread.ManagedThreadId;
                cde.Signal();
            }      
        }
    }
}
