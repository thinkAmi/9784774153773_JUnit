using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch20.ex02
{
    public class LogAnalyzer
    {
        private ILogLoader logLoader = new LogLoader();

        public LogAnalyzer(ILogLoader logLoader)
        {
            this.logLoader = logLoader;
        }

        public object Analyze(string file)
        {
            try
            {
                Dictionary<string, string> rawData = logLoader.Load(file);
                return DoAnalyze(rawData);
            }
            catch (System.IO.IOException e)
            {
                throw new AnalyzeException(e);
            }
        }

        public object DoAnalyze(Dictionary<string, string> rawData)
        {
            // これは仮実装です
            return new object();
        }
    }


    // C#の制限なのか、例外クラスは外に出した
    public class AnalyzeException : System.Exception
    {
        public AnalyzeException(System.Exception cause) : base(cause.Message, cause) { }
    }
}
