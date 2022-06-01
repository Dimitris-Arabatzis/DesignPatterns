using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// Have a singleton instance of an object per thread.
    /// 
    /// You could of course do it with DI Container with a lifetime "per thread".
    /// </summary>
    public class PerThreadSingleton
    {
        private static ThreadLocal<PerThreadSingleton> threadInstance 
            = new ThreadLocal<PerThreadSingleton>(
            ()=> new PerThreadSingleton());

        public int Id;

        public static PerThreadSingleton Instance => threadInstance.Value;

        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }
    }
}
