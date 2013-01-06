    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch19.ex06;

namespace test.ch19.ex06
{
    [TestFixture]
    public class FrameworksTest
    {
        static Dictionary<string, bool> support = new Dictionary<string, bool>();


        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            string path = @".\ch19\ex06\support.txt";
            Encoding encode = System.Text.Encoding.GetEncoding("Shift_JIS");
            string[] lines = System.IO.File.ReadAllLines(path, encode);

            foreach (var line in lines)
            {
                string[] columns = line.Split('|');
                support.Add(columns[0] + '-' + columns[1], bool.Parse(columns[2]));
            }
        }

        [Datapoints]
        public Array applicationServers = Enum.GetValues(typeof(Frameworks.ApplicationSerers));

        [Datapoints]
        public Array database = Enum.GetValues(typeof(Frameworks.Databases));


        [Theory]
        public void IsSupportはTrueを返す(Frameworks.ApplicationSerers appServer, Frameworks.Databases database)
        {
            Assume.That(IsSupport(appServer, database));

            string description = "AppServer:" + appServer.ToString() + ", DB:" + database.ToString();
            Assert.That(Frameworks.IsSupport(appServer, database), Is.True, description);
        }

        [Theory]
        public void IsSupportはFalseを返す(Frameworks.ApplicationSerers appServer, Frameworks.Databases database)
        {
            Assume.That(!(IsSupport(appServer, database)));

            string description = "AppServer:" + appServer.ToString() + ", DB:" + database.ToString();
            Assert.That(Frameworks.IsSupport(appServer, database), Is.False, description);
        }


        private bool IsSupport(Frameworks.ApplicationSerers appServer, Frameworks.Databases database)
        {
            //  Enumの数値が入ってくるので、文字列へと変換して比較する
            //  Enumを文字列化する場合、ToString() では遅いらしいが、今回は置いておく
            return support[appServer.ToString() + '-' + database.ToString()];

        }
    }
}
