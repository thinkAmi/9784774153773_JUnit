using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch20.ex02
{
    public interface ILogLoader
    {
        Dictionary<string, string> Load(string file);
    }

    public class LogLoader : ILogLoader
    {
        public Dictionary<string, string> Load(string file)
        {
            //  これは仮実装です
            return new Dictionary<string, string>();
        }
    }
}
