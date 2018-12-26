using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorLiteCommon
{
    public class Lock
    {
        readonly object lockObj;
        int recurseCount;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <returns></returns>
        public static Lock Create()
        {
            return new Lock();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        Lock()
        {
            this.lockObj = new object();
            this.recurseCount = 0;
        }

        /// <summary>
        /// Enter read mode
        /// </summary>
        public void EnterReadLock()
        {
            System.Threading.Monitor.Enter(lockObj);
            if (recurseCount != 0)
            {
                System.Threading.Monitor.Exit(lockObj);
                throw new Exception("Recursive locks aren't supported");
            }
            recurseCount++;
        }

        /// <summary>
        /// Exit read mode
        /// </summary>
        public void ExitReadLock()
        {
            if (recurseCount <= 0)
                throw new Exception("Too many exit lock method calls");
            recurseCount--;
            System.Threading.Monitor.Exit(lockObj);
        }

        /// <summary>
        /// Enter write mode
        /// </summary>
        public void EnterWriteLock()
        {
            System.Threading.Monitor.Enter(lockObj);
            if (recurseCount != 0)
            {
                System.Threading.Monitor.Exit(lockObj);
                throw new Exception("Recursive locks aren't supported");
            }
            recurseCount--;
        }

        /// <summary>
        /// Exit write mode
        /// </summary>
        public void ExitWriteLock()
        {
            if (recurseCount >= 0)
                throw new Exception("Too many exit lock method calls");
            recurseCount++;
            System.Threading.Monitor.Exit(lockObj);
        }
    }
}
