using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace production.ch18.ex06
{
    public class BackgroundTask
    {
        private readonly Task task;

        public BackgroundTask(Task task)
        {
            this.task = task;
        }

        public void Invoke()
        {
            task.Start();
        }
    }


    public class BackgroundTaskByThread
    {
        private readonly Thread task;

        public BackgroundTaskByThread(Thread task)
        {
            this.task = task;
        }

        public void Invoke()
        {
            task.Start();
        }
    }
}
