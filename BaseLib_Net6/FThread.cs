using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseLib_Net6
{
    /// <summary>To relieve the annoyance of thread management.</summary>
    public class FThread
    {
        private delegate void ThreadFunc();

        /// <summary>Number and Order of Threads</summary>
        public enum eTHREAD
        {
            /// <summary>Thread 1</summary>
            TH1 = 0,
            /// <summary>Thread 2</summary>
            TH2,
            /// <summary>Thread 3</summary>
            TH3,
            /// <summary>Thread 4</summary>
            TH4,
            /// <summary>Thread 5</summary>
            TH5,
            /// <summary>Thread 6</summary>
            TH6,
            /// <summary>Thread 7</summary>
            TH7,
            /// <summary>Thread 8</summary>
            TH8,
            /// <summary>Thread 9</summary>
            TH9,
            /// <summary>Thread 10</summary>
            TH10,
            /// <summary>Thread Count</summary>
            TH_COUNT,
        }
        private struct stThread
        {
            public Thread _th;
            public int _interval;
            public ManualResetEvent _thRun;
        }

        private stThread[] _thread;
        private ThreadFunc[] _threadFunc;

        /// <summary>FThread generator</summary>
        public FThread()
        {
            _thread = new stThread[(int)eTHREAD.TH_COUNT];
            _threadFunc = new ThreadFunc[(int)eTHREAD.TH_COUNT];
            _threadFunc[(int)eTHREAD.TH1] = ThreadFunc1;
            _threadFunc[(int)eTHREAD.TH2] = ThreadFunc2;
            _threadFunc[(int)eTHREAD.TH3] = ThreadFunc3;
            _threadFunc[(int)eTHREAD.TH4] = ThreadFunc4;
            _threadFunc[(int)eTHREAD.TH5] = ThreadFunc5;
            _threadFunc[(int)eTHREAD.TH6] = ThreadFunc6;
            _threadFunc[(int)eTHREAD.TH7] = ThreadFunc7;
            _threadFunc[(int)eTHREAD.TH8] = ThreadFunc8;
            _threadFunc[(int)eTHREAD.TH9] = ThreadFunc9;
            _threadFunc[(int)eTHREAD.TH10] = ThreadFunc10;
            _thread[(int)eTHREAD.TH1]._interval = 10;
            _thread[(int)eTHREAD.TH2]._interval = 10;
            _thread[(int)eTHREAD.TH3]._interval = 10;
            _thread[(int)eTHREAD.TH4]._interval = 10;
            _thread[(int)eTHREAD.TH5]._interval = 10;
            _thread[(int)eTHREAD.TH6]._interval = 10;
            _thread[(int)eTHREAD.TH7]._interval = 10;
            _thread[(int)eTHREAD.TH8]._interval = 10;
            _thread[(int)eTHREAD.TH9]._interval = 10;
            _thread[(int)eTHREAD.TH10]._interval = 10;
            _thread[(int)eTHREAD.TH1]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH2]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH3]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH4]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH5]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH6]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH7]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH8]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH9]._thRun = new ManualResetEvent(false);
            _thread[(int)eTHREAD.TH10]._thRun = new ManualResetEvent(false);
        }
        /// <summary>FThread destructor</summary>
        ~FThread()
        {

        }

        private void ThreadFunc1()
        {
            PreThread1();
            while (_thread[(int)eTHREAD.TH1]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH1]._interval);
                if (_thread[(int)eTHREAD.TH1]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH1]._thRun.WaitOne();
                }
                if (ProcThread1() == false)
                {
                    break;
                }
            }
            PostThread1();
        }
        private void ThreadFunc2()
        {
            PreThread2();
            while (_thread[(int)eTHREAD.TH2]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH2]._interval);
                if (_thread[(int)eTHREAD.TH2]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH2]._thRun.WaitOne();
                }
                if (ProcThread2() == false)
                {
                    break;
                }
            }
            PostThread2();
        }
        private void ThreadFunc3()
        {
            PreThread3();
            while (_thread[(int)eTHREAD.TH3]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH3]._interval);
                if (_thread[(int)eTHREAD.TH3]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH3]._thRun.WaitOne();
                }
                if (ProcThread3() == false)
                {
                    break;
                }
            }
            PostThread3();
        }
        private void ThreadFunc4()
        {
            PreThread4();
            while (_thread[(int)eTHREAD.TH4]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH4]._interval);
                if (_thread[(int)eTHREAD.TH4]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH4]._thRun.WaitOne();
                }
                if (ProcThread4() == false)
                {
                    break;
                }
            }
            PostThread4();
        }
        private void ThreadFunc5()
        {
            PreThread5();
            while (_thread[(int)eTHREAD.TH5]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH5]._interval);
                if (_thread[(int)eTHREAD.TH5]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH5]._thRun.WaitOne();
                }
                if (ProcThread5() == false)
                {
                    break;
                }
            }
            PostThread5();
        }
        private void ThreadFunc6()
        {
            PreThread6();
            while (_thread[(int)eTHREAD.TH6]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH6]._interval);
                if (_thread[(int)eTHREAD.TH6]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH6]._thRun.WaitOne();
                }
                if (ProcThread6() == false)
                {
                    break;
                }
            }
            PostThread6();
        }
        private void ThreadFunc7()
        {
            PreThread7();
            while (_thread[(int)eTHREAD.TH7]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH7]._interval);
                if (_thread[(int)eTHREAD.TH7]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH7]._thRun.WaitOne();
                }
                if (ProcThread7() == false)
                {
                    break;
                }
            }
            PostThread7();
        }
        private void ThreadFunc8()
        {
            PreThread8();
            while (_thread[(int)eTHREAD.TH8]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH8]._interval);
                if (_thread[(int)eTHREAD.TH8]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH8]._thRun.WaitOne();
                }
                if (ProcThread8() == false)
                {
                    break;
                }
            }
            PostThread8();
        }
        private void ThreadFunc9()
        {
            PreThread9();
            while (_thread[(int)eTHREAD.TH9]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH9]._interval);
                if (_thread[(int)eTHREAD.TH9]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH9]._thRun.WaitOne();
                }
                if (ProcThread9() == false)
                {
                    break;
                }
            }
            PostThread9();
        }
        private void ThreadFunc10()
        {
            PreThread10();
            while (_thread[(int)eTHREAD.TH10]._thRun.SafeWaitHandle.IsClosed == false)
            {
                Thread.Sleep(_thread[(int)eTHREAD.TH10]._interval);
                if (_thread[(int)eTHREAD.TH10]._thRun.SafeWaitHandle.IsClosed == false)
                {
                    _thread[(int)eTHREAD.TH10]._thRun.WaitOne();
                }
                if (ProcThread2() == false)
                {
                    break;
                }
            }
            PostThread10();
        }

        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread1() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread2() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread3() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread4() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread5() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread6() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread7() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread8() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread9() { return; }
        /// <remarks>The first run when the thread is created.</remarks>
        public virtual void PreThread10() { return; }

        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread1() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread2() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread3() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread4() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread5() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread6() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread7() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread8() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread9() { return; }
        /// <remarks>The last time the thread is closed.</remarks>
        public virtual void PostThread10() { return; }

        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread1() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread2() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread3() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread4() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread5() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread6() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread7() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread8() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread9() { return false; }
        /// <returns>true : infinite, false : one time</returns>
        public virtual bool ProcThread10() { return false; }

        /// <summary>Changed the interval of the thread corresponding to the enum value.
        /// Default : 10ms
        /// </summary>
        /// <param name="threadEnum">refer to enum eTHREAD</param>
        /// <param name="interval">unit : ms</param>
        public void SetThreadInterval(eTHREAD threadEnum, int interval)
        {
            if (threadEnum == eTHREAD.TH_COUNT)
            {
                return;
            }
            bool result = Enum.IsDefined(typeof(eTHREAD), threadEnum);
            if (result)
            {
                _thread[(int)threadEnum]._interval = interval;
            }
        }
        /// <summary>Create and Run Thread</summary>
        /// <param name="threadEnum">refer to enum eTHREAD</param>
        public void CreateThread(eTHREAD threadEnum)
        {
            if (threadEnum == eTHREAD.TH_COUNT)
            {
                return;
            }
            bool result = Enum.IsDefined(typeof(eTHREAD), threadEnum);
            if (result)
            {
                if (_thread[(int)threadEnum]._th == null)
                {
                    _thread[(int)threadEnum]._th = new Thread(new ThreadStart(_threadFunc[(int)threadEnum]));
                }
                else if (_thread[(int)threadEnum]._th.IsAlive == false)
                {
                    _thread[(int)threadEnum]._th = new Thread(new ThreadStart(_threadFunc[(int)threadEnum]));
                }
                if (_thread[(int)threadEnum]._thRun.SafeWaitHandle.IsClosed)
                {
                    _thread[(int)threadEnum]._thRun = new ManualResetEvent(false);
                }
                if (_thread[(int)threadEnum]._th.IsAlive == true)
                {
                    return;
                }
                _thread[(int)threadEnum]._thRun.Set();
                _thread[(int)threadEnum]._th.Start();
            }
        }
        /// <summary>Close Thread</summary>
        /// <param name="threadEnum">refer to enum eTHREAD</param>
        public void CloseThread(eTHREAD threadEnum = eTHREAD.TH_COUNT)
        {
            bool result = Enum.IsDefined(typeof(eTHREAD), threadEnum);
            if (result)
            {
                if (threadEnum == eTHREAD.TH_COUNT)
                {
                    for (int i = 0; i < (int)eTHREAD.TH_COUNT; i++)
                    {
                        if (_thread[i]._thRun.SafeWaitHandle.IsClosed == false)
                        {
                            _thread[i]._thRun.Set();
                        }
                        if (_thread[i]._thRun.SafeWaitHandle.IsClosed == false)
                        {
                            _thread[i]._thRun.Close();
                        }
                    }
                }
                else
                {
                    if (_thread[(int)threadEnum]._thRun.SafeWaitHandle.IsClosed == false)
                    {
                        _thread[(int)threadEnum]._thRun.Set();
                    }
                    if (_thread[(int)threadEnum]._thRun.SafeWaitHandle.IsClosed == false)
                    {
                        _thread[(int)threadEnum]._thRun.Close();
                    }
                }
            }
        }
        /// <summary>Puase Thread</summary>
        /// <param name="threadEnum">refer to enum eTHREAD</param>
        public void PauseThread(eTHREAD threadEnum = eTHREAD.TH_COUNT)
        {
            bool result = Enum.IsDefined(typeof(eTHREAD), threadEnum);
            if (result)
            {
                if (threadEnum == eTHREAD.TH_COUNT)
                {
                    for (int i = 0; i < (int)eTHREAD.TH_COUNT; i++)
                    {
                        if (_thread[i]._thRun.SafeWaitHandle.IsClosed == false)
                        {
                            _thread[i]._thRun.Reset();
                        }
                    }
                }
                else
                {
                    if (_thread[(int)threadEnum]._thRun.SafeWaitHandle.IsClosed == false)
                    {
                        _thread[(int)threadEnum]._thRun.Reset();
                    }
                }
            }
        }
        /// <summary>
        /// pause and restart
        /// </summary>
        /// <param name="threadEnum">refer to enum eTHREAD</param>
        public void ReStartThread(eTHREAD threadEnum = eTHREAD.TH_COUNT)
        {
            bool result = Enum.IsDefined(typeof(eTHREAD), threadEnum);
            if (result)
            {
                if (threadEnum == eTHREAD.TH_COUNT)
                {
                    for (int i = 0; i < (int)eTHREAD.TH_COUNT; i++)
                    {
                        if (_thread[i]._thRun.SafeWaitHandle.IsClosed == false)
                        {
                            _thread[i]._thRun.Set();
                        }
                    }
                }
                else
                {
                    if (_thread[(int)threadEnum]._thRun.SafeWaitHandle.IsClosed == false)
                    {
                        _thread[(int)threadEnum]._thRun.Set();
                    }
                }
            }
        }

        /// <summary>After closing the thread, wait for an end.</summary>
        /// <param name="threadEnum">refer to enum eTHREAD</param>
        public void WaitThreadTerminate(eTHREAD threadEnum = eTHREAD.TH_COUNT)
        {
            bool result = Enum.IsDefined(typeof(eTHREAD), threadEnum);
            if (result)
            {
                if (threadEnum == eTHREAD.TH_COUNT)
                {
                    for (int i = 0; i < (int)eTHREAD.TH_COUNT; i++)
                    {
                        if (_thread[i]._th == null)
                        {
                            continue;
                        }
                        if (_thread[i]._thRun.SafeWaitHandle.IsClosed == true)
                        {
                            _thread[i]._th.Join();
                        }
                    }
                }
                else
                {
                    if (_thread[(int)threadEnum]._th != null)
                    {
                        if (_thread[(int)threadEnum]._thRun.SafeWaitHandle.IsClosed == true)
                        {
                            _thread[(int)threadEnum]._th.Join();
                        }
                    }
                }
            }
        }
        /// <param name="threadEnum">refer to enum eTHREAD</param>
        /// <returns>return true if thread is alive.</returns>
        public bool IsAliveThread(eTHREAD threadEnum)
        {
            if (threadEnum == eTHREAD.TH_COUNT)
            {
                return false;
            }
            bool result = Enum.IsDefined(typeof(eTHREAD), threadEnum);
            if (result)
            {
                if (_thread[(int)threadEnum]._th == null)
                {
                    return false;
                }
                return _thread[(int)threadEnum]._th.IsAlive;
            }

            return false;
        }
    }
}
